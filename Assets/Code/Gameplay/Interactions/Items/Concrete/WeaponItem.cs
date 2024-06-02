using Battle.Weapons;
using Infrastructure.AssetsManagement.Refs;
using Infrastructure.Factories.Items;
using UnityEngine;
using VContainer;

namespace Interactions.Items.Concrete {
   [CreateAssetMenu(menuName = "item/new WeaponItem")]
   public class WeaponItem : Item {
      public AssetComponentRef<Weapon> weapon;

      private WeaponFactory _weaponFactory;



      [Inject]
      public void Construct(WeaponFactory weaponFactory) {
         _weaponFactory = weaponFactory;
      }

      public override void Apply(Entity entity) {
         entity.WeaponOwner.Try(wo => wo.Weapon = _weaponFactory.Ins(weapon));
      }

      public override void Revoke(Entity entity) { }
   }
}