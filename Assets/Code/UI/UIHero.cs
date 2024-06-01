using Units.Hero;
using UnityEngine;

namespace UI {
   public class UIHero : MonoBehaviour {
      public UIHealthBar       healthBar;
      public UIWeaponReloading weaponReloading;

      private Hero _hero;

      public Hero Hero {
         get => _hero;
         set {
            healthBar.Health       = null;
            weaponReloading.Weapon = null;

            if (!(_hero = value))
               return;

            healthBar.Health       = _hero.entity.Health.ValueOrDefault();
            weaponReloading.Weapon = _hero.entity.WeaponOwner.enabled ? _hero.entity.WeaponOwner.value.Weapon : null;
         }
      }
   }
}