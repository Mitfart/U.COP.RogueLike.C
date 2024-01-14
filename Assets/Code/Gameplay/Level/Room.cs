using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Level {
   public class Room : MonoBehaviour, IRoom {
      [SerializeField] private RoomType         type;
      [SerializeField] private Vector3          enterPoint;
      [SerializeField] private List<Vector3>    exitPoints;
      [SerializeField] private List<SpawnPoint> spawnPoints;

      public RoomType                 Type        => type;
      public Vector3                  EnterPoint  => enterPoint;
      public IEnumerable<Vector3>     ExitPoints  => exitPoints;
      public IEnumerable<ISpawnPoint> SpawnPoints => spawnPoints;
   }
}