using Infrastructure.AssetsManagement;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Factories.Hero {
   public class HeroFactory : Factory {
      private const string _CONTAINER_NAME = "Heroes";

      public Units.Hero.Hero Hero { get; private set; }



      public HeroFactory(IAssets assets, IObjectResolver di) : base(assets, di) {
         InsHero();
      }

      public Units.Hero.Hero Spawn(Vector3 at) {
         if (Hero.IsUnityNull())
            InsHero();

         Hero.entity.Position = at;
         return Hero;
      }

      private Units.Hero.Hero InsHero() {
         Hero = assets.Ins<Units.Hero.Hero>(
            "HERO",
            parent: Container(_CONTAINER_NAME)
         );
         di.InjectGameObject(Hero.gameObject);
         return Hero;
      }
   }
}