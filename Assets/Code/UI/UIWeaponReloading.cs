using Battle.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
   public class UIWeaponReloading : MonoBehaviour {
      public Image weaponImage;
      public Image maskImage;
      public Image maskEffect;

      private Weapon _weapon;

      public Weapon Weapon {
         get => _weapon;
         set {
            if (_weapon) {
               _weapon.Reloading.OnProcess -= Redraw;
            }

            _weapon = value;

            if (_weapon) {
               _weapon.Reloading.OnProcess += Redraw;
               Redraw(completion: 1f);
            }
         }
      }

      private void Redraw(float completion) {
         weaponImage.sprite    = maskImage.sprite = _weapon.sprite;
         maskEffect.fillAmount = 1f - completion;
      }
   }
}