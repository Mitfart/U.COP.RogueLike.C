using System.Collections.Generic;
using System.Linq;
using Interactions.Loot;
using UnityEngine;

namespace Locations {
   public class Room : MonoBehaviour, IRoom {
      private const float _RADIUS = .1f;

      [SerializeField] private RoomType                 type;
      [SerializeField] private Transform                enterPoint;
      [SerializeField] private List<Transform>          exitPoints;
      [SerializeField] private List<EnemySpawnPoint>    enemyPoints;
      [SerializeField] private List<TreasureSpawnPoint> treasurePoints;

      public RoomType                          Type           => type;
      public Vector3                           EnterPoint     => enterPoint.position;
      public IEnumerable<Vector3>              ExitPoints     => exitPoints.Select(t => t.position);
      public IEnumerable<SpawnPoint<Entity>>   EnemyPoints    => enemyPoints;
      public IEnumerable<SpawnPoint<Treasure>> TreasurePoints => treasurePoints;

      public void DestroySelf() => Destroy(gameObject);



      private void OnDrawGizmos() {
         Gizmos.color = Color.green;
         Gizmos.DrawSphere(EnterPoint, _RADIUS);

         Gizmos.color = Color.yellow;

         foreach (Vector3 exitPoint in ExitPoints)
            Gizmos.DrawSphere(exitPoint, _RADIUS);

         Gizmos.color = Color.red;

         foreach (ISpawnPoint enemyPoint in EnemyPoints)
            Gizmos.DrawSphere(enemyPoint.Position, _RADIUS);

         Gizmos.color = Color.magenta;

         foreach (ISpawnPoint treasurePoint in TreasurePoints)
            Gizmos.DrawSphere(treasurePoint.Position, _RADIUS);
      }

      private void OnValidate() {
         exitPoints  = exitPoints.ToHashSet().ToList();
         enemyPoints = enemyPoints.ToHashSet().ToList();
      }
   }
}