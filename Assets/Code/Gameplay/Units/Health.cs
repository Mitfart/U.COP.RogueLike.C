using System;
using Attributes.ReadOnly;
using UnityEngine;

namespace Units {
   public class Health : MonoBehaviour {
      public event Action<float> OnDamage;
      public event Action<float> OnHeal;
      public event Action        OnZero;

      public float max;

      [SerializeField, ReadOnly] private float current;

      public float Current {
         get => current;
         set => current = Mathf.Clamp(value, 0, max);
      }



      private void Awake() {
         current = max;
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



      public void IncreaseMax(float increase) {
         increase =  Mathf.Max(0, increase);
         max      += increase;

         Heal(increase);
      }

      public void DecreaseMax(float decrease) {
         decrease =  Mathf.Min(0, decrease);
         max      -= decrease;

         Damage(decrease);
      }
   }
}