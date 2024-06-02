using Infrastructure.AssetsManagement;
using Infrastructure.GameSM;
using Infrastructure.GameSM.States;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace Infrastructure.Factories.Hero {
   public class HeroFactory : Factory {
      private const string _TAG  = "HEROES";
      private const string _HERO = "HERO";

      private readonly GameStateMachine _gameStateMachine;

      public Units.Hero.Hero Hero { get; private set; }



      public HeroFactory(IAssets assets, IObjectResolver di, GameStateMachine gameStateMachine) : base(assets, di) {
         _gameStateMachine = gameStateMachine;
      }

      public override void Reset() {
         base.Reset();

         if (!Hero.IsUnityNull())
            Object.Destroy(Hero.gameObject);
      }



      public Units.Hero.Hero Spawn(Vector3 at) {
         if (Hero.IsUnityNull())
            InsHero(at);

         Hero.entity.Position = at;
         return Hero;
      }



      private Units.Hero.Hero InsHero(Vector3 at) {
         Hero = GetOrSpawn(Hero, _HERO, Container(_TAG), at);

         Hero.entity.Health.Try(h => h.OnZero += () => _gameStateMachine.Enter<EndGameState>());

         return Hero;
      }

      public void DestroyHero() => Object.Destroy(Hero.gameObject);
   }
}