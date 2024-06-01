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
         set => current = Mathf.Clamp(value, min: 0, max);
      }

      public bool IsFull => System.Math.Abs(current - max) < Consts.EPSILON;

      private bool _zeroReached;


      private void Awake() => current = max;



      public void Damage(float damage) {
         Current -= damage;
         OnDamage?.Invoke(damage);

         if (Current <= 0 && !_zeroReached) {
            OnZero?.Invoke();
            _zeroReached = true;
         }
      }

      public void Heal(float heal) {
         Current += heal;
         OnHeal?.Invoke(heal);

         if (heal > 0)
            _zeroReached = false;
      }



      public void IncreaseMax(float increase) {
         increase =  Mathf.Max(a: 0, increase);
         max      += increase;

         Heal(increase);
      }

      public void DecreaseMax(float decrease) {
         decrease =  Mathf.Min(a: 0, decrease);
         max      -= decrease;

         Damage(decrease);
      }
   }
}