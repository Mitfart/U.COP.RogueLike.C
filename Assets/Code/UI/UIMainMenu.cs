using Infrastructure.GameSM;
using Infrastructure.GameSM.States;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI {
   public class UIMainMenu : MonoBehaviour {
      public Button               playBtn;
      public Button               exitBtn;
      public UIInfiniteBackground background;

      private GameStateMachine _gameStateMachine;



      [Inject]
      public void Construct(GameStateMachine gameStateMachine) {
         _gameStateMachine = gameStateMachine;
      }

      private void OnEnable() {
         playBtn.onClick.AddListener(StartGame);
         exitBtn.onClick.AddListener(CloseGame);
      }

      private void OnDisable() {
         playBtn.onClick.RemoveListener(StartGame);
         exitBtn.onClick.RemoveListener(CloseGame);
      }


      public UIMainMenu SetRoot(UIRoot uiRoot) {
         uiRoot.EventSystem.SetSelectedGameObject(playBtn.gameObject);
         return this;
      }


      public void StartGame() => _gameStateMachine.Enter<StartGameState>();
      public void CloseGame() => Application.Quit();
   }
}