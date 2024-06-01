using System.Collections.Generic;
using Infrastructure.Factories;
using Infrastructure.Factories.UI;
using Infrastructure.Loading;
using Infrastructure.Services.Input;
using Locations;

namespace Infrastructure.GameSM.States {
   public class EndGameState : GameState {
      private readonly IInputService         _inputService;
      private readonly Level                 _level;
      private readonly UIFactory             _uiFactory;
      private readonly IEnumerable<IFactory> _factories;

      private readonly ILoadingCurtain _loading;



      public EndGameState(
         GameStateMachine      gameStateMachine,
         Level                 level,
         UIFactory             uiFactory,
         IEnumerable<IFactory> factories,
         IInputService         inputService,
         ILoadingCurtain       loading
      ) : base(gameStateMachine) {
         _loading      = loading;
         _level        = level;
         _inputService = inputService;
         _uiFactory    = uiFactory;
         _factories    = factories;
      }

      public override void Enter() {
         _uiFactory.InsEndGameScreen(win: true);
      }

      public override async void Exit() {
         _inputService.Disable();

         await _loading.Begin();

         UnloadLevel();
         _level.Reset();
      }


      private void UnloadLevel() {
         _level.Room?.DestroySelf();

         foreach (IFactory factory in _factories)
            factory.Reset();
      }
   }
}