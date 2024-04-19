using System;
using UnityEngine;

namespace Attributes.ReadOnly {
   [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
   public class ReadOnlyAttribute : PropertyAttribute { }
}