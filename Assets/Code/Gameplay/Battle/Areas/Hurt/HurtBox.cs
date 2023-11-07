using System.Collections.Generic;
using Extentions;
using UnityEngine;

namespace Gameplay.Battle.Areas.Hurt {
   public class HurtBox : HurtArea {
      public Vector2 size = Vector2.one;
      


      protected override IEnumerable<RaycastHit2D> Cast()
         => Physics2D.BoxCastAll(
            transform.position,
            size,
            transform.eulerAngles.z,
            transform.GetDirection(direction),
            Consts.EPSILON,
            layers
         );

      protected override void DrawGizmos() => UGizmos.DrawFilledBox(size, transform.localToWorldMatrix);
   }
}