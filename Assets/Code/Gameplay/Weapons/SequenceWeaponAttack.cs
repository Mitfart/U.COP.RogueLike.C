using System.Threading.Tasks;
using Structs.Optional;
using UnityEngine;

namespace Gameplay.Weapons {
   public class SequenceWeaponAttack : CombinedWeaponAttack {
      [SerializeField] private Optional<float> timeBetween;



      public override async Task Perform(Weapon weapon) {
         foreach (WeaponAttack attack in attacks) {
            await attack.Perform(weapon);

            if (timeBetween.enabled)
               await Awaitable.WaitForSecondsAsync(timeBetween.value);
         }
      }
   }
}