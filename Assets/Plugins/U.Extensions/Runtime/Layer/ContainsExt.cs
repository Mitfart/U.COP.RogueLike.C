using UnityEngine;

namespace Layer {
   public static class ContainsExt {
      public static bool Contains(this ref LayerMask mask, Component  component) => mask.Contains(component.gameObject);
      public static bool Contains(this ref LayerMask mask, GameObject go)        => mask.Contains(go.layer);
      public static bool Contains(this ref LayerMask mask, LayerMask  layerMask) => mask.Contains((int)layerMask);
      public static bool Contains(this ref LayerMask mask, int        layer)     => ((1 << layer) & mask) != 0;
   }
}