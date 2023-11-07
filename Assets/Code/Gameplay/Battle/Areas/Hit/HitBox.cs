using Extentions;
using UnityEngine;

namespace Gameplay.Battle.Areas.Hit {
   [RequireComponent(typeof(BoxCollider2D))]
   public class HitBox : HitArea {
      [SerializeField] private new BoxCollider2D collider;

      private void OnDrawGizmos() {
         collider ??= GetComponent<BoxCollider2D>();

         Gizmos.color = Color.green;

         new Rect(
            collider.offset,
            collider.size
         ).DrawGizmos(transform);
      }
   }
}