using Battle.Weapons;
using Infrastructure.AssetsManagement;
using Infrastructure.AssetsManagement.Refs;
using Infrastructure.Factories.Hero;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace Envirenment.Interactions.Items.Concrete {
   public class WeaponItem : Item {
      public AssetComponentRef<Weapon> weapon;

      private IAssets _assets;
      private Weapon  _weaponIns;



      [Inject]
      public void Construct(HeroFactory heroFactory, IAssets assets) {
         _assets = assets;
         base.Construct(heroFactory);
      }

      public override void Apply(Entity entity) {
         if (!entity.WeaponOwner.enabled)
            return;

         if (!entity.WeaponOwner.value.Weapon.IsUnityNull())
            Destroy(entity.WeaponOwner.value.Weapon.gameObject);

         entity.WeaponOwner.value.Weapon = _weaponIns;
      }

      public override void Revoke(Entity entity) {
         if (!entity.WeaponOwner.enabled)
            return;

         if (!_weaponIns.IsUnityNull())
            Destroy(_weaponIns.gameObject);
      }

      public override void PickItem() {
         _weaponIns = _assets.Ins<Weapon>(weapon);
         base.PickItem();
      }
   }
}