using System.Linq;
using Infrastructure.AssetsManagement.Refs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Locations {
   public abstract class SpawnPoint<T> : MonoBehaviour, ISpawnPoint where T : Component {
      [SerializeField] private string debugName = "SP";

      [field: SerializeField] public AssetComponentRef<T> TypedPrefab { get; private set; }

      public object  Key      => TypedPrefab;
      public Vector2 Position => transform.position;

      public string DebugName {
         get {
#if UNITY_EDITOR
            return TypedPrefab.IsUnityNull() || TypedPrefab.editorAsset.IsUnityNull()
               ? "NONE"
               : TypedPrefab.editorAsset.name;
#else
            return string.Empty;
#endif
         }
      }



      private void OnDrawGizmos() {
         if (Application.isPlaying)
            return;

         name = $"[ {debugName} ]__{DebugName}__{Addressables.LoadResourceLocationsAsync(TypedPrefab).WaitForCompletion().FirstOrDefault()?.PrimaryKey}";
      }
   }

   public interface ISpawnPoint {
      public object  Key       { get; }
      public Vector2 Position  { get; }
      public string  DebugName { get; }
   }
}