using Infrastructure.Factories.UI;
using Infrastructure.Loading;
using Infrastructure.Services.Input;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.GameSM.States {
   public class BootstrapState : GameState {
      private readonly ILoadingCurtain _loading;
      private readonly IInputService   _inputService;
      private readonly UIFactory       _uiFactory;

      private UIMainMenu _uiMainMenu;



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

         await SceneManager.LoadSceneAsync(sceneName: "Main");

         _uiMainMenu = _uiFactory.InsMainMenu();
         _uiMainMenu.background.Sync(_loading.Background);

         await _loading.End();
      }

      public override async void Exit() {
         _inputService.Disable();
         
         _loading.Background.Sync(_uiMainMenu.background);
         await _loading.Begin();

         Object.Destroy(_uiMainMenu.gameObject);
      }
   }
}