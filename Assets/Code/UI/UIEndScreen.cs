using DG.Tweening;
using EasyButtons;
using Infrastructure.GameSM;
using Infrastructure.GameSM.States;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI {
   public class UIEndScreen : MonoBehaviour {
      public Button      exitBtn;
      public CanvasGroup menu;
      public float       fadeDuration = .5f;
      public Ease        easeCurve    = Ease.InOutSine;

      private GameStateMachine _gameStateMachine;



      [Inject]
      public void Construct(GameStateMachine gameStateMachine) {
         _gameStateMachine = gameStateMachine;
      }

      public UIEndScreen SetRoot(UIRoot uiRoot) {
         uiRoot.EventSystem.SetSelectedGameObject(exitBtn.gameObject);
         return this;
      }

      private void Start() => OpenAnimation();

      private void OnEnable()  => exitBtn.onClick.AddListener(ToMainMenu);
      private void OnDisable() => exitBtn.onClick.RemoveListener(ToMainMenu);



      [Button(Mode = ButtonMode.EnabledInPlayMode)] public void ToMainMenu() => _gameStateMachine.Enter<BootstrapState>();

      public UIEndScreen WinView(bool win = true) => this;



      private void OpenAnimation() {
         menu.alpha = 0f;
         menu
           .DOFade(endValue: 1f, fadeDuration)
           .SetEase(easeCurve);
      }
   }
}