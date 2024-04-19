using StateMachine;

namespace Infrastructure.GameSM {
   public abstract class GameState<TData> : BaseGameState, IEnterableState<TData> {
      protected GameState(GameStateMachine gameStateMachine) : base(gameStateMachine) { }

      public abstract void Enter(TData data);
   }
}