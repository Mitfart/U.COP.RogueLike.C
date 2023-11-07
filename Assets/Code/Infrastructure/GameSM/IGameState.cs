using StateMachine;

namespace Infrastructure.GameSM {
   public interface IGameState : IState<IGameState, IGameStateMachine> { }
}