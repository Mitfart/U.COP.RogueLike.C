using Infrastructure.AssetsManagement.Refs;
using UnityEngine;

namespace Level {
   public class SpawnPoint {
      public Vector2                      Position;
      public AssetComponentRef<Transform> Enemy;
   }
}