using Units.Hero;
using Unity.VisualScripting;
using UnityEngine;

namespace UI {
   public class UIHero : MonoBehaviour {
      public UIHealthBar       healthBar;
      public UIWeaponReloading weaponReloading;

      private Hero _hero;

      public Hero Hero {
         get => _hero;
         set {
            healthBar.Health            = null;
            weaponReloading.WeaponOwner = null;

            _hero = value;

            if (_hero.IsUnityNull())
               return;

            healthBar.Health            = _hero.entity.Health.ValueOrDefault();
            weaponReloading.WeaponOwner = _hero.entity.WeaponOwner.ValueOrDefault();
         }
      }
   }
}