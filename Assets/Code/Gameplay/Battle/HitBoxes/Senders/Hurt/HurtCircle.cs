using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace Battle.HitBoxes.Senders.Hurt {
   public class HurtCircle : HurtArea {
      [SerializeField] private float radius = .5f;

      public float Radius => radius * transform.lossyScale.x;


      protected override IEnumerable<RaycastHit2D> Cast() {
         Transform self = transform;

         return Physics2D.CircleCastAll(
            self.Position2D(),
            Radius,
            transform.GetDirection(direction),
            -Time.deltaTime,
            Layers
         );
      }

      protected override void DrawGizmos() => UGizmos.DrawFilledSphere(radius, matrix: transform.localToWorldMatrix);
   }
}