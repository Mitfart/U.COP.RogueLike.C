using UnityEngine;

namespace Extentions {
   public static class SetParentExt {
      public static GameObject SetParent(this GameObject obj, Transform parent) {
         obj.transform.SetParent(parent);
         return obj;
      }

      public static TComp SetParent<TComp>(this TComp obj, Transform parent) where TComp : Component {
         obj.transform.SetParent(parent);
         return obj;
      }
   }
}