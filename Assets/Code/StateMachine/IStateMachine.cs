using System.Collections.Generic;

namespace StateMachine {
   public interface IStateMachine<in TStateContract, TStateMachine>
      where TStateContract : IState<TStateContract, TStateMachine>
      where TStateMachine : IStateMachine<TStateContract, TStateMachine> {
      public void RegisterStates(IEnumerable<TStateContract> gameStates);

      void Enter<TState>() where TState : class, TStateContract, IEnterableState;
      void Enter<TState, TData>(TData data) where TState : class, TStateContract, IEnterableState<TData>;
   }
}