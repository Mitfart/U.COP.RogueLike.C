using UnityEngine;

namespace Infrastructure.GameSM.States {
   public class BootstrapState : GameState {
      public BootstrapState(GameStateMachine gameStateMachine) : base(gameStateMachine) { }

      public override void Enter() {
         Debug.Log("Main Menu -> Play Imitation");
         // StateMachine.Enter<SetupGameState>();
      }
   }
}