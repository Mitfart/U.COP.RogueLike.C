using System.Collections.Generic;
using Envirenment.Locations;
using Extentions;
using Infrastructure.AssetsManagement;
using Infrastructure.Factories;
using Infrastructure.Factories.Enemy;
using Infrastructure.Factories.Hero;
using Infrastructure.Factories.Items;
using Infrastructure.Factories.Level;
using Infrastructure.Factories.UIFactory;
using Infrastructure.GameSM;
using Infrastructure.GameSM.States;
using Infrastructure.Loading;
using Infrastructure.Services.Input;
using Infrastructure.Services.Random;
using Infrastructure.Services.Time;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Scopes {
   public class GameScope : LifetimeScope {
      public  LocationsSet      defaultLocationsSet;
      public  Render.Render     render;
      public  LoadingCurtain    loadingCurtain;
      private IContainerBuilder _di;



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


      private void RegTimeService() {
         _di.Register<ITimeService, TimeService>(Lifetime.Singleton);
      }

      private void RegRandomService() {
         _di.Register<IRandomService, RandomService>(Lifetime.Singleton);
      }

      private void RegInputService() {
         _di.Register<InputService>(Lifetime.Singleton).AsImplementedInterfaces();
      }

      private void RegAssets() {
         _di.Register<IAssets, Assets>(Lifetime.Singleton);
      }

      private void RegSharedObjects() {
         Reg(render);
         Reg(loadingCurtain);
         return;

         void Reg<T>(T prefab) where T : Component {
            _di.RegisterComponentInNewPrefab(prefab, Lifetime.Singleton).DontDestroyOnLoad().AsImplementedInterfaces();
         }
      }



      private void RegLocations() {
         _di.RegScriptable(defaultLocationsSet);
      }

      private void RegLevel() {
         _di.Register<Level>(Lifetime.Singleton);
      }

      private void RegFactories() {
         Reg<UIFactory>();
         Reg<LevelFactory>();
         Reg<EnemiesFactory>();
         Reg<HeroFactory>();
         Reg<ItemsFactory>();
         return;


         void Reg<TFactory>() where TFactory : Factory {
            _di.Register<TFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
         }
      }


      private void RegGameStateMachine() {
         _di.Register<GameStateMachine>(Lifetime.Singleton);
         _di.RegisterBuildCallback(
            r => {
               var states = r.Resolve<IReadOnlyList<BaseGameState>>();
               r.Resolve<GameStateMachine>().RegisterStates(states);
            }
         );
      }

      private void RegStates() {
         Reg<BootstrapState>();
         Reg<StartGameState>();
         Reg<LoadLevelState>();
         Reg<GameplayState>();
         return;


         void Reg<TState>() where TState : BaseGameState {
            _di.Register<BaseGameState, TState>(Lifetime.Singleton);
         }
      }
   }
}