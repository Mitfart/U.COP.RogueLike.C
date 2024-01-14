using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Level {
   public interface IRoom {
      public RoomType                 Type        { get; }
      public Vector3                  EnterPoint  { get; }
      public IEnumerable<Vector3>     ExitPoints  { get; }
      public IEnumerable<ISpawnPoint> SpawnPoints { get; }
   }
}