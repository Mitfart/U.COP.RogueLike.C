using StateMachine;

namespace Infrastructure.GameSM {
   public interface IGameStateMachine : IStateMachine<IGameState, IGameStateMachine> { }
}