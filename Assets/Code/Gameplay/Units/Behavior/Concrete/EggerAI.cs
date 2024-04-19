using Extensions.Gizmos;
using Movements;
using Units.Behavior.Components;
using Units.Behavior.Nodes;
using Units.Behavior.Tree;
using UnityEngine;

namespace Units.Behavior.Concrete {
   public class EggerAI : AIBrain {
      public AITarget target;

      [Space] //
      public Movement2D movement;

      public Vector2 waitTime;

      [Space] //
      public float runSpeed;

      public float         explodeDistance;
      public SelfExplosion selfExplosion;

      private float _defaultSpeed;



      protected override Node[] CreateBehavior() {
         _defaultSpeed = movement.Speed;

         return new Node[] {
            new Repeat( //
               new IfHasTarget(
                  target,
                  new IfTargetClose(
                     target,
                     explodeDistance,
                     new CompositionNode( //
                        new DontMove(movement),
                        new Do(() => selfExplosion.Explode())
                     ),
                     new CompositionNode( //
                        new Do(() => movement.SetSpeed(runSpeed)),
                        new MoveToTarget(target, movement)
                     )
                  ),
                  new CompositionNode( //
                     new Do(() => movement.SetSpeed(_defaultSpeed)),
                     MoveRandomly()
                  )
               )
            )
         };
      }



      private void OnDrawGizmos() {
         Vector3 selfPos = Self.Position;

         Gizmos.color = Color.red;
         UGizmos.DrawFilledSphere(explodeDistance, selfPos);

         Gizmos.color = Color.blue;
         UGizmos.DrawFilledSphere(_defaultSpeed, selfPos);

         if (!Application.isPlaying)
            return;

         Gizmos.color = Color.yellow;
         Gizmos.DrawLine(selfPos, target.Position);
      }

      private Node MoveRandomly() => new MoveRandomly(target, waitTime, _defaultSpeed, movement);
   }
}