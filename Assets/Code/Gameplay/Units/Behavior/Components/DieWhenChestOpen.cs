using Extensions;
using Infrastructure.Factories.Level;
using Interactions.Loot;
using UnityEngine;
using VContainer;

namespace Units.Behavior.Components {
   public class DieWhenChestOpen : MonoBehaviour {
      public Entity entity;
      public When   when;

      private LevelFactory _levelFactory;



      [Inject]
      public void Construct(LevelFactory levelFactory) {
         _levelFactory = levelFactory;
      }

      private void Update() {
         var allClaimed = true;

         foreach (Treasure treasure in _levelFactory.Treasures) {
            allClaimed = allClaimed && treasure.Claimed;

            if (when == When.Any && allClaimed)
               entity.Die();
         }

         if (when == When.All && allClaimed)
            entity.Die();
      }
   }
}