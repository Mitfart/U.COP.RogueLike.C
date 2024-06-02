using Battle.Weapons.Attacks;
using UnityEngine;

namespace Interactions.Items.Concrete {
   [CreateAssetMenu(menuName = "item/new ChangeBulletsCountItem")]
   public class ChangeBulletsCountItem : Item {
      public int amount;

      public override void Apply(Entity entity) {
         entity.WeaponOwner.Try(
            wo => {
               if (wo.Weapon.attackMethod is not RangeWeaponAttack rangeAttack)
                  return;

               rangeAttack.spawner.BulletsCount += amount;

               float minSpread = 5 * rangeAttack.spawner.BulletsCount;
               rangeAttack.spawner.SpreadAngle = Mathf.Max(rangeAttack.spawner.SpreadAngle, minSpread);
            }
         );
      }

      public override void Revoke(Entity entity) {
         entity.WeaponOwner.Try(
            wo => {
               if (wo.Weapon.attackMethod is not RangeWeaponAttack rangeAttack)
                  return;

               rangeAttack.spawner.BulletsCount -= amount;
            }
         );
      }
   }
}