using System;
using UnityEngine;

namespace Extentions {
   public static class GetDirectionExt {
      public static Vector2 GetDirection(this Transform transform, Direction direction) {
         return direction switch {
            Direction.None  => Vector3.zero,
            Direction.Up    => transform.up,
            Direction.Right => transform.right,
            Direction.Down  => -transform.up,
            Direction.Left  => -transform.right,
            _               => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
         };
      }

      public static Vector2 AsVector(this Direction direction) {
         return direction switch {
            Direction.None  => Vector3.zero,
            Direction.Up    => Vector3.up,
            Direction.Right => Vector3.right,
            Direction.Down  => -Vector3.up,
            Direction.Left  => -Vector3.right,
            _               => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
         };
      }
   }

   public enum Direction {
      None  = 0,
      Up    = 1,
      Right = 2,
      Down  = 3,
      Left  = 4
   }
}