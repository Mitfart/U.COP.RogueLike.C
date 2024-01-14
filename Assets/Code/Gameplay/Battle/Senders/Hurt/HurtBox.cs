using System.Collections.Generic;
using Extentions;
using UnityEngine;

namespace Gameplay.Battle.Senders.Hurt {
   public class HurtBox : HurtArea {
      public Vector2 size = Vector2.one;



      protected override IEnumerable<RaycastHit2D> Cast() {
         Transform self = transform;
         return Physics2D.BoxCastAll(
            self.position,
            size,
            self.eulerAngles.z,
            transform.GetDirection(direction),
            Consts.EPSILON,
            layers
         );
      }

      protected override void DrawGizmos() {
         UGizmos.DrawFilledBox(size, transform.localToWorldMatrix);
      }
   }
}