using Infrastructure.Factories.UIFactory;
using Infrastructure.Loading;
using Infrastructure.Services.Input;
using UI.Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.GameSM.States {
   public class BootstrapState : GameState {
      private readonly ILoadingCurtain _loading;
      private readonly IInputService   _inputService;
      private readonly UIFactory       _uiFactory;

      private MainMenu _mainMenu;



      public BootstrapState( //
         GameStateMachine gameStateMachine,
         ILoadingCurtain  loading,
         IInputService    inputService,
         UIFactory        uiFactory
      ) : base(gameStateMachine) {
         _loading      = loading;
         _inputService = inputService;
         _uiFactory    = uiFactory;
      }



      public override async void Enter() {
         await _loading.Begin();

         await SceneManager.LoadSceneAsync("Main");

         _mainMenu = _uiFactory.InsMainMenu();

         await _loading.End();
      }

      public override async void Exit() {
         _inputService.Disable();

         await _loading.Begin();

         Object.Destroy(_mainMenu.gameObject);
      }
   }
}