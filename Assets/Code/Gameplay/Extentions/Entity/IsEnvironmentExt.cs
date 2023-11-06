using Layer;
using UnityEngine;

namespace Gameplay.Extentions {
   public static class IsEnvironmentExt {
      public static readonly LayerMask EnvironmentMask = LayerMask.GetMask("Environment");

      public static bool IsEnvironment(this Entity entity) => EnvironmentMask.Contains(entity);
   }
}