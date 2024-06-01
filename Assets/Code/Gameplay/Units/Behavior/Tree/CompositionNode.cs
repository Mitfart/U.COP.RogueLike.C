using System.Collections.Generic;
using VContainer;

namespace Units.Behavior.Tree {
   public class CompositionNode : Node {
      protected IReadOnlyList<Node> Children { get; }



      public CompositionNode(params Node[] children) {
         Children = children;
      }

      [Inject] //
      public void Inject(IObjectResolver di) {
         foreach (Node child in Children) {
            di.Inject(child);
         }
      }



      protected override void OnInit() {
         foreach (Node child in Children) {
            child.Init(Entity);
         }
      }

      protected override Status OnRun() {
         Status status = Status.Succes;

         foreach (Node child in Children) {
            if (child.Run() == Status.Run)
               status = Status.Run;
         }

         return status;
      }
   }
}