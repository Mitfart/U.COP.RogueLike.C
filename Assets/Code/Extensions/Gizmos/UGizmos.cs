using System;
using UnityEngine;

namespace Extensions {
   public static class UGizmos {
      public const float FILL_OPACITY_SCALE   = .1f;
      public const float BORDER_OPACITY_SCALE = 1f;



      public static void DrawFilledBox(
         Vector3    size,
         Vector3    origin        = default,
         Matrix4x4? matrix        = null,
         float      fillOpacity   = FILL_OPACITY_SCALE,
         float      borderOpacity = BORDER_OPACITY_SCALE
      )
         => DrawFilled(
            matrix ?? Matrix4x4.identity,
            fillOpacity,
            borderOpacity,
            () => UnityEngine.Gizmos.DrawCube(origin, size),
            () => UnityEngine.Gizmos.DrawWireCube(origin, size)
         );



      public static void DrawFilledSphere(
         float      radius,
         Vector3    origin        = default,
         Matrix4x4? matrix        = null,
         float      fillOpacity   = FILL_OPACITY_SCALE,
         float      borderOpacity = BORDER_OPACITY_SCALE
      )
         => DrawFilled(
            matrix ?? Matrix4x4.identity,
            fillOpacity,
            borderOpacity,
            () => UnityEngine.Gizmos.DrawSphere(origin, radius),
            () => UnityEngine.Gizmos.DrawWireSphere(origin, radius)
         );



      public static void DrawFilled(
         Matrix4x4 matrix,
         float     fillOpacity,
         float     borderOpacity,
         Action    fill,
         Action    border
      ) {
         Matrix4x4 m = UnityEngine.Gizmos.matrix;
         float     a = UnityEngine.Gizmos.color.a;

         UnityEngine.Gizmos.matrix = matrix;

         SetColorAlpha(a * fillOpacity);
         fill?.Invoke();

         SetColorAlpha(a * borderOpacity);
         border?.Invoke();

         UnityEngine.Gizmos.matrix = m;
         SetColorAlpha(a);
      }



      public static void SetColorAlpha(float opacity) {
         Color col = UnityEngine.Gizmos.color;
         col.a                    = opacity;
         UnityEngine.Gizmos.color = col;
      }
   }
}