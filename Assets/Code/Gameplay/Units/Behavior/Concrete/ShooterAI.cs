using Extensions;
using Movements;
using Units.Behavior.Components;
using Units.Behavior.Nodes;
using Units.Behavior.Tree;
using UnityEngine;

namespace Units.Behavior.Concrete {
   public class ShooterAI : AIBrain {
      public AITarget  target;
      public Team      team;
      public LayerMask layerMask;
      public float     viewRadius;

      [Space] //
      public Movement2D movement;

      public Vector2 moveDistance;
      public Vector2 waitTime;

      [Space] //
      public WeaponOwner weaponOwner;

      public float prepareTime;



      private void OnEnable() {
         weaponOwner.Weapon.reloadDuration = Mathf.Max(weaponOwner.Weapon.reloadDuration, prepareTime);
      }

      protected override Node[] CreateBehavior()
         => new Node[] {
            new Repeat( //
               new IfHasTarget(
                  target,
                  new CompositionNode( //
                     new ShootAtTarget(target, weaponOwner, prepareTime),
                     new IfTargetClose(
                        target,
                        moveDistance.x,
                        new MoveFromTarget(target, movement),
                        new IfTargetFar(
                           target,
                           moveDistance.y,
                           new MoveToTarget(target, movement),
                           new DontMove(movement)
                        )
                     )
                  ),
                  IfSeeTarget(
                     new None(),
                     MoveRandomly()
                  )
               )
            )
         };



      private Node IfSeeTarget(Node @true, Node @false)
         => new IfFoundTarget(
            target,
            viewRadius,
            team,
            layerMask,
            @true,
            @false
         );

      private Node MoveToTarget() => new MoveToTarget(target, movement);
      private Node MoveRandomly() => new MoveRandomly(target, waitTime, viewRadius, movement);



      private void OnDrawGizmos() {
         Vector3 selfPos = Self.Position;

         Gizmos.color = Color.green;
         UGizmos.DrawFilledSphere(moveDistance.y, selfPos);

         Gizmos.color = Color.red;
         UGizmos.DrawFilledSphere(moveDistance.x, selfPos);

         Gizmos.color = Color.blue;
         UGizmos.DrawFilledSphere(viewRadius, selfPos);

         if (!Application.isPlaying)
            return;

         Gizmos.color = Color.yellow;
         Gizmos.DrawLine(selfPos, target.Position);
      }
   }
}