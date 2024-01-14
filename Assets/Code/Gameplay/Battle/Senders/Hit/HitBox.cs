using Extentions;
using UnityEngine;

namespace Gameplay.Battle.Senders.Hit {
   [RequireComponent(typeof(BoxCollider2D))]
   public class HitBox : HitArea<BoxCollider2D> {
      protected override void OnDrawGizmos() {
         base.OnDrawGizmos();
         
         new Rect(collider.offset, collider.size).DrawGizmos(transform);
      }
   }
}