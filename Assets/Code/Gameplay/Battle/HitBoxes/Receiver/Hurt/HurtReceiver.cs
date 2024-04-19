using Battle.HitBoxes.Receiver.Hit;
using Battle.HitBoxes.Senders.Hurt;
using UnityEngine;

namespace Battle.HitBoxes.Receiver.Hurt {
   public class HurtReceiver : HitDataReceiver<HurtArea, HurtReceiver> {
      [field: SerializeField, Min(0)] public float Damage { get; private set; }

      public void SetDamage(float dmg) {
         Damage = Mathf.Max(0, dmg);
      }
   }
}