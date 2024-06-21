using System.Collections.Generic;
using Interactions.Loot;
using UnityEngine;

namespace Locations {
   public interface IRoom {
      public RoomType                          Type           { get; }
      public Vector3                           EnterPoint     { get; }
      public IEnumerable<Vector3>              ExitPoints     { get; }
      public IEnumerable<SpawnPoint<Entity>>   EnemyPoints    { get; }
      public IEnumerable<SpawnPoint<Treasure>> TreasurePoints { get; }

      public void DestroySelf();
   }
}