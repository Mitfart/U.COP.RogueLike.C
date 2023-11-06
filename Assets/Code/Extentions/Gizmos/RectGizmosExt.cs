using UnityEngine;

namespace Extentions {
   public static class RectGizmosExt {
      public static void DrawGizmos(
         this Rect rect,
         float     fillOpacity   = UGizmos.FILL_OPACITY_SCALE,
         float     borderOpacity = UGizmos.BORDER_OPACITY_SCALE
      ) {
         UGizmos.DrawFilledBox(
            rect.size,
            rect.position,
            Quaternion.identity,
            Vector3.one,
            fillOpacity,
            borderOpacity
         );
      }


      public static void DrawGizmos(
         this Rect rect,
         Transform transform,
         float     fillOpacity   = UGizmos.FILL_OPACITY_SCALE,
         float     borderOpacity = UGizmos.BORDER_OPACITY_SCALE
      ) {
         UGizmos.DrawFilledBox(
            rect.size,
            transform.position + (Vector3)rect.position,
            transform.rotation,
            transform.lossyScale,
            fillOpacity,
            borderOpacity
         );
      }
   }
}