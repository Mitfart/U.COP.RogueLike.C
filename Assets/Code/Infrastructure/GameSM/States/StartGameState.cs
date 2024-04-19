using Locations;

namespace Infrastructure.GameSM.States {
   public class StartGameState : GameState {
      private readonly LocationsSet _locations;



      public StartGameState(GameStateMachine gameStateMachine, LocationsSet locations) : base(gameStateMachine) {
         _locations = locations;
      }

      public override void Enter() {
         StateMachine.Enter<LoadLevelState, LoadData>(new LoadData(_locations.Locations[0], 0));
      }
   }
}