using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure {
   [DefaultExecutionOrder(-10)]
   public class AnySceneStarter : MonoBehaviour {
#if UNITY_EDITOR
      private void Awake() => Boot();

      [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
      private static void Boot() {
         if (FindFirstObjectByType<Bootstrap>() == null)
            Addressables.InstantiateAsync("BOOT");
      }
#endif
   }
}