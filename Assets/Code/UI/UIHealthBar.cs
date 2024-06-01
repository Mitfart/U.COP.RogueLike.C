using TMPro;
using Units;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
   public class UIHealthBar : MonoBehaviour {
      public string   textFormat = "{0} / {1}";
      public TMP_Text textMeshPro;
      public Image    heartImage;

      private Health _health;

      public Health Health {
         get => _health;
         set {
            if (_health) {
               _health.OnDamage -= Redraw;
               _health.OnHeal   -= Redraw;
            }

            _health = value;

            if (_health) {
               _health.OnDamage += Redraw;
               _health.OnHeal   += Redraw;
               Redraw(_: 0f);
            }
         }
      }



      private void OnEnable() {
         if (!Health)
            return;

         Health.OnDamage += Redraw;
         Health.OnHeal   += Redraw;
      }

      private void OnDisable() {
         if (!Health)
            return;

         Health.OnDamage -= Redraw;
         Health.OnHeal   -= Redraw;
      }



      private void Redraw(float _) {
         textMeshPro.text      = string.Format(textFormat, _health.Current, _health.max);
         heartImage.fillAmount = _health.Current / _health.max;
      }
   }
}