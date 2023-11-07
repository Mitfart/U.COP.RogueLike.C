using Infrastructure.AssetsManagement.Refs;
using UnityEngine;

namespace Level {
   public class MonoSpawnPoint : MonoBehaviour {
      public AssetComponentRef<Transform> enemy;

      public SpawnPoint GetData()
         => new() {
            Position = transform.position, //
            Enemy    = enemy
         };
   }
}