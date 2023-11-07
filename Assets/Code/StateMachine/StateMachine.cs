using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine {
   public abstract class StateMachine<TStateContract, TStateMachine> : IStateMachine<TStateContract, TStateMachine>
      where TStateContract : IState<TStateContract, TStateMachine>
      where TStateMachine : IStateMachine<TStateContract, TStateMachine> {
      private Dictionary<Type, TStateContract> _states;

      private TStateContract _currentState;



      public void RegisterStates(IEnumerable<TStateContract> gameStates) {
         _states = gameStates.ToDictionary(state => state.GetType());
      }



      public void Enter<TState>() where TState : class, TStateContract, IEnterableState //
         => ChangeState<TState>().Enter();

      public void Enter<TState, TData>(TData data) where TState : class, TStateContract, IEnterableState<TData> //
         => ChangeState<TState>().Enter(data);



      private TState ChangeState<TState>() where TState : class, TStateContract {
         (_currentState as IExitableState)?.Exit();

         TState state = GetState<TState>();
         _currentState = state;

         return state;
      }

      private TState GetState<TState>() where TState : class, TStateContract => (TState)_states[typeof(TState)];
   }
}