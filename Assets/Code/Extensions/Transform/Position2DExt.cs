using UnityEngine;

namespace Extensions.Transform {
   public static class Position2DExt {
      public static Vector2 Position2D(this UnityEngine.Transform transform) {
         return transform.position;
      }
   }
}