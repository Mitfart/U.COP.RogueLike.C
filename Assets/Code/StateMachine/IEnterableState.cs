namespace StateMachine {
   public interface IEnterableState {
      void Enter();
   }

   public interface IEnterableState<in TData> {
      void Enter(TData data);
   }
}