using Infrastructure.AssetsManagement.Refs;
using UnityEngine;

namespace Gameplay.Level {
   public interface ISpawnPoint {
      public AssetComponentRef<Transform> Enemy    { get; }
      public Vector2                      Position { get; }
   }
}