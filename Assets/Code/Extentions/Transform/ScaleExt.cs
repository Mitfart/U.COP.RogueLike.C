using UnityEngine;

namespace Extentions {
   public static class ScaleExt {
      public static Transform Scale(this Transform transform, float value) {
         transform.localScale = Vector3.one * value;
         return transform;
      }

      public static GameObject Scale(this GameObject go, float value) {
         go.transform.Scale(value);
         return go;
      }

      public static TComp Scale<TComp>(this TComp component, float value) where TComp : Component {
         component.transform.Scale(value);
         return component;
      }
   }
}