using System.Threading.Tasks;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

namespace Units.Hero {
   public class HeroAnimator : MonoBehaviour {
      public Entity       entity;

      [Header("Jump into Level")] public Collider2D physicsCollider;
      public                             float      distance;
      public                             float      jumpPower;
      public                             float      duration;



      public async Task EnterRoom() {
         entity.gameObject.SetActive(true);
         physicsCollider.On();

         await entity.GetBody() //
                     .DOJump(entity.Position + Vector2.right * distance, jumpPower, 1, duration)
                     .AsyncWaitForCompletion();
      }

      public async Task ExitRoom(Vector3 target) {
         physicsCollider.Off();

         await entity.GetBody() //
                     .DOJump(target, jumpPower, 1, duration)
                     .AsyncWaitForCompletion();

         physicsCollider.On();
         entity.gameObject.SetActive(false);
      }
   }
}