using UnityEngine;

namespace Interactions.Items.Concrete {
   [CreateAssetMenu(menuName = "item/new ChangeWeaponReloadSpeedItem")]
   public class ChangeWeaponReloadSpeedItem : Item {
      public float reduceValue;

      public override void Apply(Entity entity)
         => entity.WeaponOwner.Try(wo => wo.Weapon.reloadDuration -= reduceValue);

      public override void Revoke(Entity entity)
         => entity.WeaponOwner.Try(wo => { wo.Weapon.reloadDuration += reduceValue; });
   }
}