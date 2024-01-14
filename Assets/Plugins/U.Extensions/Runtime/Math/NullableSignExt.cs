using UnityEngine;

namespace Math {
   public static class NullableSignExt {
      public static float NullableSign(this float a)
         => Mathf.Abs(a) > Consts.EPSILON
            ? Mathf.Sign(a)
            : 0;
   }
}