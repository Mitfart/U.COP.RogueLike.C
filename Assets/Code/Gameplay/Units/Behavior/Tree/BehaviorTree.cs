using VContainer;

namespace Units.Behavior.Tree {
   public class BehaviorTree {
      private readonly EntryNode _entry;
      public           Status    Status => _entry.Status;



      public BehaviorTree(params Node[] nodes) {
         _entry = new EntryNode(nodes);
      }

      [Inject] //
      public void Inject(IObjectResolver di) {
         di.Inject(_entry);
      }

      public void Init(Entity entity) {
         _entry.Init(entity);
      }

      public Status Run() {
         return _entry.Run();
      }
   }
}