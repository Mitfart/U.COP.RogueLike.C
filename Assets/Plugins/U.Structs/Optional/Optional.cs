using System;
using UnityEngine;

namespace Structs.Optional {
   [Serializable]
   public struct Optional<T> {
      public T    value;
      public bool enabled;

      public T ValueOrDefault() => enabled ? value : default;
   }
}