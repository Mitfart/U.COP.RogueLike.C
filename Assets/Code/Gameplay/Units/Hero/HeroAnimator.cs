using System.Threading.Tasks;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

namespace Units.Hero {
   public class HeroAnimator : MonoBehaviour {
      public Entity entity;

      [Header(header: "Jump into Level")] public Collider2D physicsCollider;
      public                                     float      distance;
      public                                     float      jumpPower;
      public                                     float      duration;



      public async Task EnterRoom() {
         entity.gameObject.SetActive(value: true);
         physicsCollider.On();

         await entity.GetBody() //
                     .DOJump(entity.Position + Vector2.right * distance, jumpPower, numJumps: 1, duration)
                     .AsyncWaitForCompletion();
      }

      public async Task ExitRoom(Vector3 target) {
         physicsCollider.Off();

         await entity.GetBody() //
                     .DOJump(target, jumpPower, numJumps: 1, duration)
                     .AsyncWaitForCompletion();

         physicsCollider.On();
         entity.gameObject.SetActive(value: false);
      }
   }
}