using Interactions.Loot;
using UnityEngine;

namespace Locations {
   public interface ITreasurePoint {
      public TreasureSize TreasureSize { get; }
      public Vector2      Position     { get; }
   }
}