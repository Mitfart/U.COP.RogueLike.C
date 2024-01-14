using Infrastructure.AssetsManagement.Refs;
using UnityEngine;

namespace Gameplay.Level {
   public class SpawnPoint : MonoBehaviour, ISpawnPoint {
      [SerializeField] private AssetComponentRef<Transform> enemy;

      public AssetComponentRef<Transform> Enemy    => enemy;
      public Vector2                      Position => transform.position;
   }
}