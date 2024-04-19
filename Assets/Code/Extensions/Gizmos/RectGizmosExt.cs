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
            Matrix4x4.identity,
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
            rect.position,
            transform.localToWorldMatrix,
            fillOpacity,
            borderOpacity
         );
      }
   }
}