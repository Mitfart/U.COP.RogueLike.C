using EasyButtons;
using UnityEngine;

namespace Gameplay.Weapons {
   public class WeaponAutoAttack : MonoBehaviour {
      [SerializeField] private Weapon weapon;
      [SerializeField] private bool   attack;


      private void Update() {
         if (attack)
            weapon.Attack();
      }

      [Button] public void StartAttack()  => attack = true;
      [Button] public void CancelAttack() => attack = false;
   }
}