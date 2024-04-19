using System;
using UnityEngine;

namespace Structs.Optional {
   [Serializable]
   public struct Optional<T> {
      public T    value;
      public bool enabled;

      public Optional(T startValue = default, bool enabled = false) {
         value        = startValue;
         this.enabled = enabled;
      }

      public T ValueOrDefault(T def = default) => enabled ? value : def;
   }
}