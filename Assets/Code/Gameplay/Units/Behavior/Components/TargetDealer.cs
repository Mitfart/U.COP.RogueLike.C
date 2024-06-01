using Battle.HitBoxes;
using Battle.HitBoxes.Listeners;

namespace Units.Behavior.Components {
   public class TargetDealer : HitListener {
      public AITarget target;

      protected override void Listen(HitData data) {
         if (data.Dealer == Owner)
            return;

         target.Set(data.Dealer);
      }
   }
}