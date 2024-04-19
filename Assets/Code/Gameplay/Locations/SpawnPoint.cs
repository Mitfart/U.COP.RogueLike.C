using System.Linq;
using Infrastructure.AssetsManagement.Refs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Locations {
   public class SpawnPoint : MonoBehaviour, ISpawnPoint {
      [SerializeField] private string                       debugName = "SP";
      [SerializeField] private AssetComponentRef<Transform> enemy;

      public AssetComponentRef<Transform> Enemy    => enemy;
      public Vector2                      Position => transform.position;

      private void OnDrawGizmos() {
         if (Application.isPlaying)
            return;

         name = $"[ {debugName} ]__{Addressables.LoadResourceLocationsAsync(enemy).WaitForCompletion().First()?.PrimaryKey}";
      }
   }
}