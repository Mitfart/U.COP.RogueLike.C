using StateMachine;

namespace Infrastructure.GameSM {
   public abstract class BaseGameState : IState<BaseGameState, GameStateMachine>, IExitableState {
      public GameStateMachine StateMachine { get; }

      protected BaseGameState(GameStateMachine gameStateMachine) {
         StateMachine = gameStateMachine;
      }

      public virtual void Exit() { }
   }
}