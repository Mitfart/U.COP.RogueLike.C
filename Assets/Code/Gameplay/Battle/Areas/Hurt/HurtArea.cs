using System.Collections.Generic;
using Extentions;
using Gameplay.Battle.Areas.Hit;
using UnityEngine;

namespace Gameplay.Battle.Areas.Hurt {
   public abstract class HurtArea : HitDataSender {
      public Direction direction = Direction.Up;
      public LayerMask layers;



      private void Update() => CheckHit();



      private void CheckHit() {
         IEnumerable<RaycastHit2D> hits = Cast();

         foreach (RaycastHit2D hit in hits) {
            if (!IsHitable(hit, out HitArea taker)) continue;

            HitData hitData = CreateHitData(hit, taker);

            taker.Send(hitData);
            Send(hitData);
         }
      }



      private bool    IsHitable(RaycastHit2D     hit, out HitArea hitBox)  => hit.collider.TryGetComponent(out hitBox);
      private HitData CreateHitData(RaycastHit2D hit, HitArea     hitArea) => new(hit, this, hitArea);



      private void OnDrawGizmos() {
         Gizmos.color = Color.red;

         DrawGizmos();
         DrawDirection();
      }

      private void DrawDirection() {
         Vector3 origin = transform.position;
         Vector2 dir    = transform.GetDirection(direction);
         Gizmos.DrawLine(origin, origin + (Vector3)dir);
      }



      protected abstract IEnumerable<RaycastHit2D> Cast();
      protected abstract void                      DrawGizmos();
   }
}