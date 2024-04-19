using System.Collections;
using UnityEngine;

namespace Battle.Bullets {
   public class BulletDestroyByLifeTime : MonoBehaviour {
      public          Bullet bullet;
      [Min(0)] public float  lifeTime;



      private void Start() {
         StartCoroutine(LifeRoutine());
      }

      private IEnumerator LifeRoutine() {
         yield return new WaitForSeconds(lifeTime);

         bullet.Destroy();
      }
   }
}