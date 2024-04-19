using Infrastructure.GameSM;
using Infrastructure.GameSM.States;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Menus {
   public class MainMenu : MonoBehaviour {
      public Button playBtn;
      public Button exitBtn;

      private GameStateMachine _gameStateMachine;



      [Inject]
      public void Construct(GameStateMachine gameStateMachine) {
         _gameStateMachine = gameStateMachine;
         StartGame();
      }

      private void OnEnable() {
         playBtn.onClick.AddListener(StartGame);
         exitBtn.onClick.AddListener(CloseGame);
      }

      private void OnDisable() {
         playBtn.onClick.RemoveListener(StartGame);
         exitBtn.onClick.RemoveListener(CloseGame);
      }



      private void StartGame() => _gameStateMachine.Enter<StartGameState>();
      private void CloseGame() => Application.Quit();
   }
}