using Extentions;
using UnityEngine;

namespace _Extentions {
   public static class IsEnvironmentExt {
      public static readonly LayerMask EnvironmentMask = LayerMask.GetMask("Environment");

      public static bool IsEnvironment(this Entity entity) {
         return EnvironmentMask.Contains(entity);
      }
   }
}