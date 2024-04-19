using Infrastructure.Services.Input;

namespace Infrastructure.GameSM.States {
   public class GameplayState : GameState {
      private readonly IInputService _inputService;



      public GameplayState(GameStateMachine gameStateMachine, IInputService inputService) : base(gameStateMachine) {
         _inputService = inputService;
      }

      public override void Enter() {
         _inputService.Enable();
      }

      public override void Exit() {
         _inputService.Disable();
      }
   }
}