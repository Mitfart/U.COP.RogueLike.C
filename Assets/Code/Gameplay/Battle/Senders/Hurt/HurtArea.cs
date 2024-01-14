using System.Collections.Generic;
using Gameplay.Battle.Senders.Hit;
using UnityEngine;

namespace Gameplay.Battle.Senders.Hurt {
   [DisallowMultipleComponent]
   public abstract class HurtArea : HitDataSender {
      public string    areaName;
      public Direction direction = Direction.Up;
      public LayerMask layers;

      protected virtual string DefaultAreaName => GetType().Name;



      private void Update() {
         CheckHit();
      }
      
      private void OnDrawGizmos() {
         Gizmos.color = Color.red;

         SetAreaName();
         DrawGizmos();
         DrawDirection();
      }



      private void CheckHit() {
         IEnumerable<RaycastHit2D> hits = Cast();

         foreach (RaycastHit2D hit in hits) {
            if (!IsHitable(hit, out HitArea taker)) continue;

            HitData hitData = CreateHitData(hit, taker);

            taker.Send(hitData);
            Send(hitData);
         }
      }



      private static bool IsHitable(RaycastHit2D hit, out HitArea hitBox) {
         return hit.collider.TryGetComponent(out hitBox);
      }

      private HitData CreateHitData(RaycastHit2D hit, HitArea hitArea) {
         return new HitData(hit, this, hitArea);
      }

      
      
      private void SetAreaName() {
         name = string.IsNullOrWhiteSpace(areaName) ? DefaultAreaName : areaName;
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