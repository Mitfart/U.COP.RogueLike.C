using System;
using System.Threading.Tasks;
using Infrastructure.AssetsManagement;
using Infrastructure.AssetsManagement.Refs;
using Structs.Optional;
using UnityEngine;
using VContainer;

namespace Gameplay.Bullets.Spawners {
   public class BulletsSpawner : Spawner<Bullet> {
      private const float _MIN_SPREAD = 0F;
      private const float _MAX_SPREAD = 360F;

      public          AssetComponentRef<Bullet> bullet;
      [Min(1)] public int                       bulletsCount;
      public          float                     spawnOffset;
      public          Optional<float>           spawnGapTime;

      [Range(_MIN_SPREAD, _MAX_SPREAD), SerializeField] private float spreadAngle;

      public bool invert;

      private IAssets _assets;
      private float   _angleBetween;
      private float   _halfSpreadAngle;

      public float SpreadAngle {
         get => spreadAngle;
         set {
            spreadAngle = Mathf.Clamp(value, _MIN_SPREAD, _MAX_SPREAD);

            if (bulletsCount > 1) {
               _angleBetween    = spreadAngle / (bulletsCount - 1);
               _halfSpreadAngle = spreadAngle * .5f;
            } else
               _angleBetween = _halfSpreadAngle = 0;

            if (_angleBetween > _MAX_SPREAD - spreadAngle) {
               _angleBetween    = _MAX_SPREAD / bulletsCount;
               _halfSpreadAngle = _MAX_SPREAD * .5f;
            }
         }
      }



      [Inject]
      public void Construct(IAssets assets) {
         _assets = assets;
      }

      private void Start()      => SpreadAngle = spreadAngle;
      private void OnValidate() => SpreadAngle = spreadAngle;

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



      private Bullet SpawnBullet(Vector2 at, Quaternion rot) => _assets.Ins<Bullet>(bullet, at, rot);


      private Vector2    CalcPosition(Quaternion  rot) => transform.position + CalcOffset(rot);
      private Vector3    CalcOffset(Quaternion    rot) => CalcOffsetDir(rot) * spawnOffset;
      private Vector3    CalcOffsetDir(Quaternion rot) => rot                * Vector3.right;
      private Quaternion CalcRotation(int         i)   => Quaternion.Euler(Vector3.forward * CalcAngle(i));

      private float CalcAngle(int i) => -_halfSpreadAngle + _angleBetween * i + transform.eulerAngles.z + (invert ? 180 : 0);
   }
}