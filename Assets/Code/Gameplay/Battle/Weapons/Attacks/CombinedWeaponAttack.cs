using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Battle.Weapons.Attacks {
   public class CombinedWeaponAttack : WeaponAttack {
      [SerializeField] protected List<WeaponAttack> attacks;

      private Task[] _attackTasks;



      private void Awake() => _attackTasks = new Task[attacks.Count];

      public override Task Perform(Weapon weapon) {
         for (var i = 0; i < attacks.Count; i++) {
            _attackTasks[i] = attacks[i].Perform(weapon);
         }

         return Task.WhenAll(_attackTasks);
      }
   }
}