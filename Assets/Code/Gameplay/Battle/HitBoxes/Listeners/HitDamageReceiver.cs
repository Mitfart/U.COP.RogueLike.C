using Battle.HitBoxes.Receiver;
using Battle.HitBoxes.Receiver.Hit;
using DefaultNamespace;
using Units;
using UnityEngine;

namespace Battle.HitBoxes.Listeners {
   [RequireComponent(typeof(HitReceiver))]
   public class HitDamageReceiver : HitListener {
      public Health health;

      protected override void Listen(HitData data) {
         if (data.Taker != Owner)
            return;

         health.Damage(data.Damage);

         if (Owner.Invulnerability.enabled)
            Owner.Invulnerability.value.On();
      }
   }
}