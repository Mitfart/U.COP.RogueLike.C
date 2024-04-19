using Envirenment.Interactions.Loot;
using UnityEngine;

namespace Envirenment.Locations {
   public interface ITreasurePoint {
      public TreasureSize TreasureSize { get; }
      public Vector2      Position     { get; }
   }
}