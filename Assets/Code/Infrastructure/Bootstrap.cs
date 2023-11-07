using Infrastructure.GameSM;
using Infrastructure.Scopes;
using UnityEngine;
using VContainer;

namespace Infrastructure {
   [RequireComponent(typeof(GameScope))]
   public class Bootstrap : MonoBehaviour {
      public GameScope scope;

      public void Awake() {
         DontDestroyOnLoad(gameObject);

         scope.Build();
         scope.autoRun = false;

         // EnterBootState();
      }

      // private void              EnterBootState()   => GameStateMachine().Enter<BootstrapState>();
      private IGameStateMachine GameStateMachine() => scope.Container.Resolve<IGameStateMachine>();
   }
}