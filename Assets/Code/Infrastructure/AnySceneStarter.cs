using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure {
   [DefaultExecutionOrder(order: -10)]
   public class AnySceneStarter : MonoBehaviour {
#if UNITY_EDITOR
      private void Awake() {
         if (FindFirstObjectByType<Bootstrap>() == null)
            Addressables.InstantiateAsync("BOOTSTRAP");
      }
#endif
   }
}