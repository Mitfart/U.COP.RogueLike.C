using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyButtons;
using UnityEngine;

namespace Gameplay.Weapons {
   public class Weapon : MonoBehaviour {
      public event Action OnBeginAttack;
      public event Action OnEndAttack;

      [SerializeField] private WeaponAttack attack;

      [field: SerializeField] public bool Blocked { get; private set; }



      [Button]
      public async Task Attack() {
         if (!Blocked) {
            OnBeginAttack?.Invoke();

            attack.Perform(this);

            OnEndAttack?.Invoke();
         }
      }

      [Button]
      public void Block() {
         Blocked = true;
      }

      [Button]
      public void Unblock() {
         Blocked = false;
      }
   }
}