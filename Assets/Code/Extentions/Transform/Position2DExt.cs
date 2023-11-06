using UnityEngine;

namespace Extentions {
   public static class Position2DExt {
      public static Vector2 Position2D(this Transform transform) => transform.position;
   }
}