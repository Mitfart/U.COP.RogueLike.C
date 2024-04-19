using Movements;
using Units.Behavior.Components;
using Units.Behavior.Tree;
using UnityEngine;

namespace Units.Behavior.Nodes {
   public class MoveFromTarget : Node {
      private readonly AITarget   _target;
      private readonly Movement2D _movement;



      public MoveFromTarget(AITarget target, Movement2D movement) {
         _target   = target;
         _movement = movement;
      }

      protected override Status OnRun() {
         Vector2 moveDestination = MirroredTargetPosition();

         _target.Set(moveDestination);
         _movement.SetDestination(moveDestination);

         return _movement.AtDestination() ? Status.Succes : Status.Run;
      }

      private Vector2 MirroredTargetPosition() => Entity.Position - (_target.Position - Entity.Position);
   }
}