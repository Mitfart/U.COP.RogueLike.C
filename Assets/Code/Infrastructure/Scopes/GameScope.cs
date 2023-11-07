using System.Collections.Generic;
using Extentions;
using Infrastructure.AssetsManagement;
using Infrastructure.Factories;
using Infrastructure.Factories.Hero;
using Infrastructure.GameSM;
using Infrastructure.Loading;
using Infrastructure.Services.Input;
using Infrastructure.Services.Random;
using Infrastructure.Services.Time;
using Level;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Scopes {
   public class GameScope : LifetimeScope {
      private IContainerBuilder _di;

      public LocationsSet   defaultLocationsSet;
      public Render.Render  render;
      public LoadingCurtain loadingCurtain;



      protected override void Configure(IContainerBuilder di) {
         _di = di;

         RegTimeService();
         RegRandomService();
         RegInputService();
         RegAssets();

         RegFactories();
         RegLocations();
         RegLevel();

         RegSharedObjects();

         RegGameStateMachine();
         RegStates();
      }


      private void RegTimeService()   => _di.Register<ITimeService, TimeService>(Lifetime.Singleton);
      private void RegRandomService() => _di.Register<IRandomService, RandomService>(Lifetime.Singleton);
      private void RegInputService()  => _di.Register<InputService>(Lifetime.Singleton).AsImplementedInterfaces();
      private void RegAssets()        => _di.Register<IAssets, Assets>(Lifetime.Singleton);

      private void RegSharedObjects() {
         Reg(render);
         Reg(loadingCurtain);
         return;

         void Reg<T>(T prefab) where T : Component {
            _di.RegisterComponentInNewPrefab(prefab, Lifetime.Singleton)
               .DontDestroyOnLoad()
               .AsImplementedInterfaces();
         }
      }



      private void RegLocations() => _di.RegScriptable(defaultLocationsSet);
      private void RegLevel()     => _di.Register<Level.Level>(Lifetime.Singleton);

      private void RegFactories() {
         Reg<HeroFactory>();


         void Reg<TFactory>() where TFactory : Factory {
            _di.Register<TFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
         }
      }


      private void RegGameStateMachine() {
         _di.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
         _di.RegisterBuildCallback(
            resolver =>
               resolver
                 .Resolve<IGameStateMachine>()
                 .RegisterStates(resolver.Resolve<IReadOnlyList<IGameState>>())
         );
      }

      private void RegStates() {
         // Reg<BootstrapState>();


         void Reg<TState>() where TState : IGameState {
            _di.Register<IGameState, TState>(Lifetime.Singleton);
         }
      }
   }
}