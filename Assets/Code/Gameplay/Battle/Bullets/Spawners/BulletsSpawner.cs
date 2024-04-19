using System;
using System.Threading.Tasks;
using Infrastructure.AssetsManagement;
using Infrastructure.AssetsManagement.Refs;
using Structs.Optional;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Battle.Bullets.Spawners {
   public class BulletsSpawner : Spawner<Bullet> {
      private const float _MIN_SPREAD      = 0F;
      private const float _MAX_SPREAD      = 360F;
      private const float _HALF_MAX_SPREAD = 180F;

      public                           AssetComponentRef<Bullet> bullet;
      [SerializeField, Min(1)] private int                       bulletsCount;
      public                           float                     spawnOffset;
      public                           Optional<float>           spawnGapTime;

      [Range(_MIN_SPREAD, _MAX_SPREAD)] [SerializeField]
      private float spreadAngle;

      public bool invert;

      private IAssets         _assets;
      private IObjectResolver _di;
      private float           _angleBetween;
      private float           _halfSpreadAngle;

      public int BulletsCount {
         get => bulletsCount;
         set {
            bulletsCount = value;
            ReCalcSpread(reCalcAngleBetween: false);
         }
      }

      public float SpreadAngle {
         get => spreadAngle;
         set {
            spreadAngle = Mathf.Clamp(value, _MIN_SPREAD, _MAX_SPREAD);
            ReCalcSpread();
         }
      }

      private void Start() {
         SpreadAngle = spreadAngle;
      }

      private void OnDrawGizmos() {
         Transform self   = transform;
         Vector3   origin = self.position;
         Vector3   arrow  = self.right * 1.5f;


         Gizmos.color = Color.green;
         Gizmos.DrawRay(origin, invert ? -arrow : arrow);


         Gizmos.color = Color.cyan;
         Gizmos.DrawSphere(origin, .1f);

         if (spreadAngle >= float.Epsilon && _MAX_SPREAD - _halfSpreadAngle * 2f >= float.Epsilon) {
            Gizmos.DrawRay(origin, Quaternion.Euler(Vector3.forward * _halfSpreadAngle)  * arrow);
            Gizmos.DrawRay(origin, Quaternion.Euler(Vector3.forward * -_halfSpreadAngle) * arrow);


            if (invert) {
               Gizmos.color = Color.yellow;
               Gizmos.DrawRay(origin, Quaternion.Euler(Vector3.forward * _halfSpreadAngle)  * -arrow);
               Gizmos.DrawRay(origin, Quaternion.Euler(Vector3.forward * -_halfSpreadAngle) * -arrow);
            }
         }


         Gizmos.color = Color.magenta;

         for (var i = 0; i < bulletsCount; i++) {
            Quaternion rotation = CalcRotation(i);
            Vector2    position = CalcPosition(rotation);
            Vector2    offset   = CalcOffsetDir(rotation);

            Gizmos.DrawRay(position, offset);
         }
      }

      private void OnValidate() {
         SpreadAngle = spreadAngle;
      }



      [Inject]
      public void Construct(IAssets assets, IObjectResolver di) {
         _di     = di;
         _assets = assets;
      }



      public override async Task Spawn(Action<Bullet> onSpawnBullet) {
         for (var i = 0; i < bulletsCount; i++) {
            Quaternion rotation = CalcRotation(i);
            Vector2    position = CalcPosition(rotation);

            Bullet newBullet = SpawnBullet(position, rotation);
            onSpawnBullet?.Invoke(newBullet);

            if (spawnGapTime.enabled)
               await Awaitable.WaitForSecondsAsync(spawnGapTime.value);
         }
      }



      private Bullet SpawnBullet(Vector2 at, Quaternion rot) {
         Bullet ins = _assets.Ins<Bullet>(bullet, at, rot);
         _di.InjectGameObject(ins.gameObject);
         return ins;
      }


      private Vector2 CalcPosition(Quaternion rot) {
         return transform.position + CalcOffset(rot);
      }

      private Vector3 CalcOffset(Quaternion rot) {
         return CalcOffsetDir(rot) * spawnOffset;
      }

      private Vector3 CalcOffsetDir(Quaternion rot) {
         return rot * Vector3.right;
      }

      private Quaternion CalcRotation(int i) {
         return Quaternion.Euler(Vector3.forward * CalcAngle(i));
      }

      private float CalcAngle(int i) {
         return -_halfSpreadAngle + _angleBetween * i + transform.eulerAngles.z + (invert ? 180 : 0);
      }



      private void ReCalcSpread(bool reCalcAngleBetween = true) {
         if (bulletsCount > 1) {
            if (reCalcAngleBetween)
               _angleBetween = spreadAngle / (bulletsCount - 1);

            _halfSpreadAngle = _angleBetween * (bulletsCount - 1) * .5f;
         } else { _angleBetween = _halfSpreadAngle = 0; }

         if (_angleBetween > _MAX_SPREAD - spreadAngle) {
            _angleBetween    = _MAX_SPREAD / bulletsCount;
            _halfSpreadAngle = _HALF_MAX_SPREAD;
         }
      }
   }
}