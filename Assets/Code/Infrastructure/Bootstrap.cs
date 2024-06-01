using Infrastructure.GameSM;
using Infrastructure.GameSM.States;
using Infrastructure.Scopes;
using UnityEngine;
using VContainer;

namespace Infrastructure {
   [RequireComponent(typeof(GameScope)), DefaultExecutionOrder(order: -5)]
   public class Bootstrap : MonoBehaviour {
      public GameScope scope;



      public void Awake() {
         DontDestroyOnLoad(gameObject);

         scope.autoRun = false;
         scope.Build();

         EnterBootState();
      }

      private void OnDrawGizmos() => scope ??= GetComponent<GameScope>();



      private void EnterBootState() => GameStateMachine().Enter<BootstrapState>();

      private GameStateMachine GameStateMachine() => scope.Container.Resolve<GameStateMachine>();
   }
}