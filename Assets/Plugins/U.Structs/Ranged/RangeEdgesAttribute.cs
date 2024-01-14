using System;
using UnityEngine;

namespace Structs.Ranged {
   [AttributeUsage(AttributeTargets.Field)]
   public class RangeEdgesAttribute : PropertyAttribute {
      public readonly float Max;
      public readonly float Min;

      public RangeEdgesAttribute(float min, float max) {
         Min = Mathf.Min(min, max);
         Max = Mathf.Max(min, max);
      }
   }
}