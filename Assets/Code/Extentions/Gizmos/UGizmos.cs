using System;
using UnityEngine;

namespace Extentions {
   public static class UGizmos {
      public const float FILL_OPACITY_SCALE   = .1f;
      public const float BORDER_OPACITY_SCALE = 1f;



      public static void DrawFilledBox(
         Vector3    size,
         Matrix4x4? matrix        = null,
         float      fillOpacity   = FILL_OPACITY_SCALE,
         float      borderOpacity = BORDER_OPACITY_SCALE
      )
         => DrawFilled(
            matrix ?? Matrix4x4.identity,
            fillOpacity,
            borderOpacity,
            () => Gizmos.DrawCube(Vector3.zero, size),
            () => Gizmos.DrawWireCube(Vector3.zero, size)
         );

      public static void DrawFilledBox(
         Vector3     size,
         Vector3     position      = default,
         Quaternion? rotation      = null,
         Vector3?    scale         = null,
         float       fillOpacity   = FILL_OPACITY_SCALE,
         float       borderOpacity = BORDER_OPACITY_SCALE
      )
         => DrawFilledBox(
            size,
            Matrix4x4.TRS(position, rotation ?? Quaternion.identity, scale ?? Vector3.zero),
            fillOpacity,
            borderOpacity
         );



      public static void DrawFilledSphere(
         float      radius,
         Matrix4x4? matrix        = null,
         float      fillOpacity   = FILL_OPACITY_SCALE,
         float      borderOpacity = BORDER_OPACITY_SCALE
      )
         => DrawFilled(
            matrix ?? Matrix4x4.identity,
            fillOpacity,
            borderOpacity,
            () => Gizmos.DrawSphere(Vector3.zero, radius),
            () => Gizmos.DrawWireSphere(Vector3.zero, radius)
         );

      public static void DrawFilledSphere(
         float       radius,
         Vector3     position      = default,
         Quaternion? rotation      = null,
         Vector3?    scale         = null,
         float       fillOpacity   = FILL_OPACITY_SCALE,
         float       borderOpacity = BORDER_OPACITY_SCALE
      )
         => DrawFilledSphere(
            radius,
            Matrix4x4.TRS(position, rotation ?? Quaternion.identity, scale ?? Vector3.zero),
            fillOpacity,
            borderOpacity
         );



      public static void DrawFilled(
         Matrix4x4 matrix,
         float     fillOpacity,
         float     borderOpacity,
         Action    fill,
         Action    border
      ) {
         Matrix4x4 m = Gizmos.matrix;
         float     a = Gizmos.color.a;

         Gizmos.matrix = matrix;

         SetColorAlpha(a * fillOpacity);
         fill?.Invoke();

         SetColorAlpha(a * borderOpacity);
         border?.Invoke();

         Gizmos.matrix = m;
         SetColorAlpha(a);
      }

      

      public static void SetColorAlpha(float opacity) {
         Color col = Gizmos.color;
         col.a        = opacity;
         Gizmos.color = col;
      }
   }
}