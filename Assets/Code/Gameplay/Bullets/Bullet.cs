using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Bullets {
   public class Bullet : MonoBehaviour {
      public Weapon Source { get; private set; }

      public float speed;


      public Bullet Init(Weapon weapon) {
         Source = weapon;
         return this;
      }

      private void Update() {
         transform.Translate(Vector3.right * (speed * Time.deltaTime));
      }


      public void Destroy() => Destroy(gameObject);
   }
}