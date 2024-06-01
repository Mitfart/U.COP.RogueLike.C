using System;
using Battle.HitBoxes.Receiver.Hurt;
using Battle.HitBoxes.Senders.Hurt;
using Battle.Weapons;
using UnityEngine;

namespace Battle.Bullets {
   public class Bullet : MonoBehaviour {
      public event Action OnDestroy;

      [field: SerializeField] public HurtReceiver Receiver { get; private set; }

      public Weapon Source { get; private set; }
      public Entity Entity => Source.receiver.Owner;



      public Bullet Init(Weapon weapon) {
         Source = weapon;
         Source.receiver.Add(Receiver);

         foreach (HurtArea hurtArea in Receiver.Senders) {
            hurtArea.baseDamage = weapon.Damage;
         }

         return this;
      }

      public void Destroy() {
         OnDestroy?.Invoke();
         Source.receiver.Remove(Receiver);
         Destroy(gameObject);
      }
   }
}