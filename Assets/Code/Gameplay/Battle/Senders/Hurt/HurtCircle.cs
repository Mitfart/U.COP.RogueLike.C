using System.Collections.Generic;
using Extentions;
using UnityEngine;

namespace Gameplay.Battle.Senders.Hurt {
   public class HurtCircle : HurtArea {
      public float radius = .5f;



      protected override IEnumerable<RaycastHit2D> Cast()
         => Physics2D.CircleCastAll(
            transform.Position2D(),
            radius,
            transform.GetDirection(direction),
            Consts.EPSILON,
            layers
         );

      protected override void DrawGizmos() {
         UGizmos.DrawFilledSphere(radius, transform.localToWorldMatrix);
      }
   }
}