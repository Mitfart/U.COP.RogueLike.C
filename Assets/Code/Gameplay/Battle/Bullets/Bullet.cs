using System;
using Battle.HitBoxes.Receiver.Hurt;
using Battle.Weapons;
using UnityEngine;

namespace Battle.Bullets {
   public class Bullet : MonoBehaviour {
      public event Action OnDestroy;

      [field: SerializeField] public HurtReceiver Receiver { get; private set; }

      public Weapon Source { get; private set; }
      public Entity Entity => Source.Receiver.Owner;



      public Bullet Init(Weapon weapon) {
         Source = weapon;
         Source.Receiver.Add(Receiver);
         Receiver.SetDamage(Source.Receiver.Damage);
         return this;
      }

      public void Destroy() {
         OnDestroy?.Invoke();
         Source.Receiver.Remove(Receiver);
         Destroy(gameObject);
      }
   }
}