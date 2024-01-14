using System;
using UnityEngine;

namespace Structs.Weighted {
   [Serializable]
   public struct Weighted<T> {
      public T     value;
      public float weight;
   }
}