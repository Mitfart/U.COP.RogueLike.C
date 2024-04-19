using Envirenment.Interactions.Loot;
using Unity.VisualScripting;
using UnityEngine;

namespace Envirenment.Locations {
   public class TreasurePoint : MonoBehaviour, ITreasurePoint {
      [field: SerializeField] public TreasureSize TreasureSize { get; private set; }

      public Vector2 Position => transform.position;

      private void OnDrawGizmos() {
         if (Application.isPlaying)
            return;

         name = $"[ Treasure ]__{TreasureSize.DisplayName()}";
      }
   }
}