using System.Collections.Generic;
using UnityEngine;

namespace Locations {
   public interface IRoom {
      public RoomType                    Type           { get; }
      public Vector3                     EnterPoint     { get; }
      public IEnumerable<Vector3>        ExitPoints     { get; }
      public IEnumerable<ISpawnPoint>    SpawnPoints    { get; }
      public IEnumerable<ITreasurePoint> TreasurePoints { get; }

      public void DestroySelf();
   }
}