using Movements;
using Units.Behavior.Tree;

namespace Units.Behavior.Nodes {
   public class DontMove : Node {
      private readonly Movement2D _movement;



      public DontMove(Movement2D movement) {
         _movement = movement;
      }

      protected override Status OnRun() {
         _movement.SetDestination(Entity.Position);
         return Status.Succes;
      }
   }
}