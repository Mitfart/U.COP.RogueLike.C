using Battle.Weapons;
using Infrastructure.AssetsManagement;
using Infrastructure.AssetsManagement.Refs;
using VContainer;

namespace Infrastructure.Factories.Items {
   public class WeaponFactory : Factory {
      public WeaponFactory(IAssets assets, IObjectResolver di) : base(assets, di) { }

      public Weapon Ins(AssetComponentRef<Weapon> weapon) => Spawn<Weapon>(weapon);
   }
}