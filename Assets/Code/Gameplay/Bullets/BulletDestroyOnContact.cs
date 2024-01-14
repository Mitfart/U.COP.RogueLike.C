using Extentions;
using UnityEngine;

namespace Gameplay.Bullets {
   public class BulletDestroyOnContact : MonoBehaviour {
      public Bullet bullet;
      public LayerMask  destroyersMask;



      private void OnTriggerEnter2D(Collider2D other) {
         if (CollideWithDestroyer(other))
            bullet.Destroy();
      }

      private bool CollideWithDestroyer(Component other) => destroyersMask.Contains(other.gameObject);
   }
}