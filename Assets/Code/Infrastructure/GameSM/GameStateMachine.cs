using StateMachine;

namespace Infrastructure.GameSM {
   public class GameStateMachine : StateMachine<IGameState, IGameStateMachine>, IGameStateMachine { }
}