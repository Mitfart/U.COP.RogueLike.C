using Battle.Special;
using UnityEngine;

namespace Battle.Bullets {
   public class ExplodeOnDestroy : MonoBehaviour {
      public Bullet    bullet;
      public Explosion explosionPrefab;



      private void OnEnable()  => bullet.OnDestroy += Explode;
      private void OnDisable() => bullet.OnDestroy -= Explode;



      private async void Explode() {
         Transform bulletBody = bullet.transform;
         Explosion expIns = Instantiate( //
            explosionPrefab,
            bulletBody.position,
            bulletBody.rotation
         );

         bullet.Source.receiver.Add(expIns.hurtCircle);

         await expIns.Explode();

         bullet.Source.receiver.Remove(expIns.hurtCircle);

         Destroy(expIns.gameObject);
      }
   }
}