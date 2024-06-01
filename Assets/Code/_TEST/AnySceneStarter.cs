using Infrastructure;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _TEST {
   [DefaultExecutionOrder(order: -15)]
   public class AnySceneStarter : MonoBehaviour {
#if UNITY_EDITOR
      private void Awake() => Boot();

      [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
      private static void Boot() {
         if (FindFirstObjectByType<Bootstrap>() == null)
            Addressables.InstantiateAsync(key: "BOOT");
      }
#endif
   }
}