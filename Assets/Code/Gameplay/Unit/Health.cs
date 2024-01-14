using System;
using UnityEngine;

namespace Gameplay.Unit {
   public class Health : MonoBehaviour {
      public event Action<float> OnDamage;
      public event Action<float> OnHeal;
      public event Action        OnZero;

      public float max;

      private float _current;

      public float Current {
         get => _current;
         set => _current = Mathf.Clamp(value, min: 0, max);
      }



      public void Damage(float damage) {
         Current -= damage;
         OnDamage?.Invoke(damage);

         if (Current <= 0)
            OnZero?.Invoke();
      }

      public void Heal(float heal) {
         Current += heal;
         OnHeal?.Invoke(heal);
      }
   }
}