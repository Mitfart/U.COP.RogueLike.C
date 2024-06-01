using DefaultNamespace;
using UnityEngine;

namespace Interactions.Items {
   public class DroppedHeart : Dropped {
      public               Team        targetTeam;
      [Min(min: 1)] public int         heal = 1;
      public               Rigidbody2D body;
      public               Collider2D  col;



      public override bool Compatible(Entity picker)
         => picker.Team == targetTeam
         && picker.Health.enabled
         && !picker.Health.value.IsFull;

      protected override void PickStart(Entity picker) {
         body.simulated = false;
         col.Off();
      }
      
      protected override void PickEnd(Entity picker) {
         picker.Health.value.Heal(heal);
      }
   }
}