using UnityEngine;

namespace Extensions {
   public static class AtDestinationExt {
      public static bool AtDestination(this   Transform self, Vector3 destination) => Vector3.Distance(self.position, destination)     <= Consts.EPSILON + Time.deltaTime;
      public static bool AtDestination2D(this Transform self, Vector2 destination) => Vector2.Distance(self.Position2D(), destination) <= Consts.EPSILON + Time.deltaTime;
   }
}