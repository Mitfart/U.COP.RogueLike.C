using Interactions.Loot;
using UnityEngine;

namespace Locations {
   public class TreasurePoint : MonoBehaviour, ITreasurePoint {
      [field: SerializeField] public TreasureSize TreasureSize { get; private set; }

      public Vector2 Position => transform.position;
      
      
      
      private void OnDrawGizmos() {
         if (Application.isPlaying)
            return;

         name = $"[ Treasure ]__{TreasureSize}";
      }
   }
}