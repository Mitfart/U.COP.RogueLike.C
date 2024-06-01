using UnityEngine;

namespace Extensions {
   public static class Position2DExt {
      public static Vector2 Position2D(this UnityEngine.Transform transform) => transform.position;
   }
}