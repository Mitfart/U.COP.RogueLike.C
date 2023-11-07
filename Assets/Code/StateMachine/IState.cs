namespace StateMachine {
   public interface IState<in TStateContract, TStateMachine>
      where TStateContract : IState<TStateContract, TStateMachine>
      where TStateMachine : IStateMachine<TStateContract, TStateMachine> {
      public TStateMachine StateMachine { get; }
   }
}