using StateMachine;

namespace Infrastructure.GameSM {
   public abstract class GameState : IState<GameState, GameStateMachine>, IEnterableState, IExitableState {
      public GameStateMachine StateMachine { get; }

      protected GameState(GameStateMachine gameStateMachine) {
         StateMachine = gameStateMachine;
      }

      public abstract void Enter();
      public virtual  void Exit() { }
   }
}