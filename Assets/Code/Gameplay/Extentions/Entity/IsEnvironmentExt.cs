using Extentions;
using UnityEngine;

namespace Gameplay.Extentions.Entity {
   public static class IsEnvironmentExt {
      public static readonly LayerMask EnvironmentMask = LayerMask.GetMask("Environment");

      public static bool IsEnvironment(this Gameplay.Entity entity) => EnvironmentMask.Contains(entity);
   }
}