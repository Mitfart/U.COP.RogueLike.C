using Extentions;
using UnityEngine;

namespace Gameplay.Battle.Areas.Hit {
   [RequireComponent(typeof(CircleCollider2D))]
   public class HitCircle : HitArea {
      [SerializeField] private new CircleCollider2D collider;

      private void OnDrawGizmos() {
         collider ??= GetComponent<CircleCollider2D>();

         Gizmos.color = Color.green;

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