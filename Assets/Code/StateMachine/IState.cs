namespace StateMachine {
   public interface IState<in TStateContract, out TStateMachine>
      where TStateContract : IState<TStateContract, TStateMachine>
      where TStateMachine : IStateMachine<TStateContract, TStateMachine> {
      public TStateMachine StateMachine { get; }
   }
}