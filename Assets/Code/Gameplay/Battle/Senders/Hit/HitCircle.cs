using Extentions;
using UnityEngine;

namespace Gameplay.Battle.Senders.Hit {
   [RequireComponent(typeof(CircleCollider2D))]
   public class HitCircle : HitArea<CircleCollider2D> {
      protected override void OnDrawGizmos() {
         base.OnDrawGizmos();

         Transform self = transform;
         UGizmos.DrawFilledSphere(
            collider.radius,
            self.position + (Vector3)collider.offset,
            self.rotation,
            self.lossyScale
         );
      }
   }
}