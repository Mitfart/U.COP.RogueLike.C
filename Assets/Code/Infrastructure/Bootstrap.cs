using Infrastructure.GameSM;
using Infrastructure.GameSM.States;
using Infrastructure.Scopes;
using UnityEngine;
using VContainer;

namespace Infrastructure {
   [RequireComponent(typeof(GameScope))]
   [DefaultExecutionOrder(-10)]
   public class Bootstrap : MonoBehaviour {
      public GameScope scope;



      public void Awake() {
         DontDestroyOnLoad(gameObject);

         scope.Build();
         scope.autoRun = false;

         EnterBootState();
      }

      private GameStateMachine GameStateMachine() {
         return scope.Container.Resolve<GameStateMachine>();
      }

      private void EnterBootState() {
         GameStateMachine().Enter<BootstrapState>();
      }


      private void OnDrawGizmos() {
         scope ??= GetComponent<GameScope>();
      }
   }
}