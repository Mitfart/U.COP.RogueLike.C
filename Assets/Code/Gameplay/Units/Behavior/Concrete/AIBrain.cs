using Units.Behavior.Tree;
using UnityEngine;
using VContainer;

namespace Units.Behavior.Concrete {
   public abstract class AIBrain : MonoBehaviour {
      [field: SerializeField] public Entity Self { get; private set; }

      private BehaviorTree _behavior;



      [Inject]
      public void Construct(IObjectResolver di) {
         _behavior = new BehaviorTree(CreateBehavior());
         di.Inject(_behavior);
         _behavior.Init(Self);
      }

      private void Update() => _behavior?.Run();



      protected abstract Node[] CreateBehavior();
   }
}