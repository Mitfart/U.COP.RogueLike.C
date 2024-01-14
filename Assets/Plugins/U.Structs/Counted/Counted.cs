using System;
using UnityEngine;

namespace Structs.Counted {
   [Serializable]
   public struct Counted<T> {
      public T   value;
      public int count;
   }
}