using Battle.Weapons.Attacks;
using UnityEngine;

namespace Interactions.Items.Concrete {
   [CreateAssetMenu(menuName = "item/new ChangeBulletsCountItem")]
   public class ChangeBulletsCountItem : Item {
      public int amount;

      public override void Apply(Entity entity) {
         if (!entity.WeaponOwner.enabled
          || entity.WeaponOwner.value.Weapon.attackMethod is not RangeWeaponAttack rangeAttack)
            return;

         rangeAttack.spawner.BulletsCount += amount;
      }

      public override void Revoke(Entity entity) {
         if (!entity.WeaponOwner.enabled
          || entity.WeaponOwner.value.Weapon.attackMethod is not RangeWeaponAttack rangeAttack)
            return;

         rangeAttack.spawner.BulletsCount -= amount;
      }
   }
}