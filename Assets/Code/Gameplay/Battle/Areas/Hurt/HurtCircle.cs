using System.Collections.Generic;
using Extentions;
using UnityEngine;

namespace Gameplay.Battle.Areas.Hurt {
   public class HurtCircle : HurtArea {
      public float radius;



      protected override IEnumerable<RaycastHit2D> Cast()
         => Physics2D.CircleCastAll(
            transform.position,
            radius,
            transform.GetDirection(direction),
            Consts.EPSILON,
            layers
         );

      protected override void DrawGizmos() => UGizmos.DrawFilledSphere(radius, transform.localToWorldMatrix);
   }
}