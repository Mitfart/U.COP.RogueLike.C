using UnityEngine;

namespace _Debug.Changers {
   public abstract class BaseChanger : MonoBehaviour {
      public abstract void Change();
      public abstract void Normalize();
   }
}