using Infrastructure.Services.Input;
using Locations;

namespace Infrastructure.GameSM.States {
   public class GameplayState : GameState {
      private readonly IInputService _inputService;
      private readonly Level         _level;



      public GameplayState(GameStateMachine gameStateMachine, IInputService inputService, Level level) : base(gameStateMachine) {
         _inputService = inputService;
         _level        = level;
      }

      public override void Enter() {
         _level.InvokeEnterEvent();
         _inputService.Enable();
      }

      public override void Exit() {
         _level.InvokeExitEvent();
         _inputService.Disable();
      }
   }
}