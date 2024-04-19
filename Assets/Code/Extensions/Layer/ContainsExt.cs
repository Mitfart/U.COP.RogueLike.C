using UnityEngine;

namespace Extentions {
   public static class ContainsExt {
      public static bool Contains(this in LayerMask mask, Component component) {
         return mask.Contains(component.gameObject);
      }

      public static bool Contains(this in LayerMask mask, GameObject go) {
         return mask.Contains(go.layer);
      }

      public static bool Contains(this in LayerMask mask, LayerMask layerMask) {
         return mask.Contains((int)layerMask);
      }

      public static bool Contains(this in LayerMask mask, int layer) {
         return ((1 << layer) & mask) != 0;
      }
   }
}