using System.Collections.Generic;
using Extensions.Gizmos;
using UnityEngine;

namespace Battle.HitBoxes.Senders.Hurt {
   public class HurtBox : HurtArea {
      [SerializeField] private Vector2 size = Vector2.one;

      public Vector2 Size => size * transform.lossyScale.x;



      protected override IEnumerable<RaycastHit2D> Cast() {
         Transform self = transform;

         return Physics2D.BoxCastAll(
            self.Position2D(),
            Size,
            self.eulerAngles.z,
            self.GetDirection(direction),
            -Time.deltaTime,
            Layers
         );
      }

      protected override void DrawGizmos() {
         UGizmos.DrawFilledBox(size, matrix: transform.localToWorldMatrix);
      }
   }
}