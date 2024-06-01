using Battle.Weapons;
using Infrastructure.AssetsManagement.Refs;
using Unity.VisualScripting;

namespace Interactions.Items.Concrete {
   public class WeaponItem : Item {
      public AssetComponentRef<Weapon> weapon;

      private Weapon _weaponIns;



      public override void Apply(Entity entity) {
         if (!entity.WeaponOwner.enabled)
            return;

         if (!entity.WeaponOwner.value.Weapon.IsUnityNull())
            Destroy(entity.WeaponOwner.value.Weapon.gameObject);

         if (_weaponIns.IsUnityNull())
            _weaponIns = weapon.InstantiateAsync()
                               .WaitForCompletion()
                               .GetComponent<Weapon>();

         entity.WeaponOwner.value.Weapon = _weaponIns;
      }

      public override void Revoke(Entity entity) {
         if (!entity.WeaponOwner.enabled)
            return;

         if (!_weaponIns.IsUnityNull())
            Destroy(_weaponIns.gameObject);
      }
   }
}