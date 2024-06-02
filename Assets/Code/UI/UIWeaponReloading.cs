using Battle.Weapons;
using Units;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
   public class UIWeaponReloading : MonoBehaviour {
      public Image weaponImage;
      public Image maskImage;
      public Image maskEffect;

      private WeaponOwner _weaponOwner;

      public WeaponOwner WeaponOwner {
         get => _weaponOwner;
         set {
            if (_weaponOwner) {
               if (_weaponOwner.Weapon)
                  _weaponOwner.Weapon.Reloading.OnProcess -= Redraw;

               _weaponOwner.OnChangeWeapon -= Redraw;
            }

            _weaponOwner = value;

            if (_weaponOwner) {
               if (_weaponOwner.Weapon)
                  _weaponOwner.Weapon.Reloading.OnProcess += Redraw;

               _weaponOwner.OnChangeWeapon += Redraw;
            }

            Redraw(completion: 1f);
         }
      }

      private void Redraw(float completion) {
         if (_weaponOwner.IsUnityNull() || _weaponOwner.Weapon.IsUnityNull()) {
            gameObject.SetActive(false);
            return;
         }

         weaponImage.sprite    = maskImage.sprite = _weaponOwner.Weapon.sprite;
         maskEffect.fillAmount = 1f - completion;
         gameObject.SetActive(true);
      }

      private void Redraw(Weapon weapon) {
         if (_weaponOwner.Weapon.IsUnityNull())
            return;

         _weaponOwner.Weapon.Reloading.OnProcess -= Redraw;
         _weaponOwner.Weapon.Reloading.OnProcess += Redraw;

         Redraw(completion: 1f);
      }
   }
}