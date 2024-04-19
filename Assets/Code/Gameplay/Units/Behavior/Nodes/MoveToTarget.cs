using Movements;
using Units.Behavior.Components;
using Units.Behavior.Tree;

namespace Units.Behavior.Nodes {
   public class MoveToTarget : Node {
      private readonly AITarget   _target;
      private readonly Movement2D _movement;
      private readonly bool       _ignoreEntity;



      public MoveToTarget(AITarget target, Movement2D movement, bool ignoreEntity = false) {
         _target       = target;
         _movement     = movement;
         _ignoreEntity = ignoreEntity;
      }

      protected override Status OnRun() {
         _movement.SetDestination(_ignoreEntity ? _target.Point : _target.Position);

         return _movement.AtDestination() ? Status.Succes : Status.Run;
      }
   }
}