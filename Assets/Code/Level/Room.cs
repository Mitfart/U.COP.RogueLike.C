using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Level {
   public class Room : MonoBehaviour {
      [SerializeField] private RoomType             type;
      [SerializeField] private Vector3              enterPoint;
      [SerializeField] private List<Vector3>        exitPoints;
      [SerializeField] private List<MonoSpawnPoint> spawnPoints;

      public RoomType                Type        { get; private set; }
      public Vector3                 EnterPoint  { get; private set; }
      public IEnumerable<Vector3>    ExitPoints  { get; private set; }
      public IEnumerable<SpawnPoint> SpawnPoints { get; private set; }



      private void Awake() {
         Type        = type;
         EnterPoint  = enterPoint;
         ExitPoints  = exitPoints;
         SpawnPoints = spawnPoints.Select(sp => sp.GetData());
      }
   }
}