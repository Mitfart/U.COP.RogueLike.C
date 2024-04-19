using StateMachine;

namespace Infrastructure.GameSM {
   public abstract class GameState : BaseGameState, IEnterableState {
      protected GameState(GameStateMachine gameStateMachine) : base(gameStateMachine) { }

      public abstract void Enter();
   }
}