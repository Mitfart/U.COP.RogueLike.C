using UnityEngine;

namespace Extensions.Transform {
   public static class SetParentExt {
      public static GameObject SetParent(this GameObject obj, UnityEngine.Transform parent) {
         obj.transform.SetParent(parent);
         return obj;
      }

      public static TComp SetParent<TComp>(this TComp obj, UnityEngine.Transform parent) where TComp : Component {
         obj.transform.SetParent(parent);
         return obj;
      }
   }
}