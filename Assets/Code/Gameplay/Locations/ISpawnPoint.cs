using Infrastructure.AssetsManagement.Refs;
using UnityEngine;

namespace Locations {
   public interface ISpawnPoint {
      public AssetComponentRef<Transform> Enemy    { get; }
      public Vector2                      Position { get; }
   }
}