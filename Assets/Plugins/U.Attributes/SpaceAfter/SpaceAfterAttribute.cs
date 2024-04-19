using System;
using UnityEngine;

namespace Attributes.ReadOnly {
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
   public class SpaceAfterAttribute : PropertyAttribute {
      public readonly float height;

      public SpaceAfterAttribute(float height = 10f) => this.height = height;
   }
}