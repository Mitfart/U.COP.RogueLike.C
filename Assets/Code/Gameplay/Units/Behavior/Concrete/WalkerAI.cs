using Extensions.Gizmos;
using Movements;
using Units.Behavior.Components;
using Units.Behavior.Nodes;
using Units.Behavior.Tree;
using Unity.VisualScripting;
using UnityEngine;

namespace Units.Behavior.Concrete {
   public class WalkerAI : AIBrain {
      public         AITarget   target;
      public         Team       team;
      public         LayerMask  layerMask;
      public         float      viewRadius;
      [Space] public Movement2D movement;
      public         Vector2    waitTime;



      protected override Node[] CreateBehavior()
         => new Node[] {
            new Repeat(
               new IfHasTarget(
                  target,
                  MoveToTarget(), //
                  IfFoundTarget(
                     new None(),
                     MoveRandomly()
                  )
               )
            )
         };



      private void OnDrawGizmos() {
         if (Self.IsUnityNull())
            return;

         Vector3 selfPos = Self.Position;

         Gizmos.color = Color.blue;
         UGizmos.DrawFilledSphere(viewRadius, selfPos);

         if (!Application.isPlaying)
            return;

         Gizmos.color = Color.yellow;
         Gizmos.DrawLine(selfPos, target.Position);
      }



      private Node IfFoundTarget(Node @true, Node @false) {
         return new IfFoundTarget(
            target,
            viewRadius,
            team,
            layerMask,
            @true,
            @false
         );
      }

      private Node MoveToTarget() => new MoveToTarget(target, movement);
      private Node MoveRandomly() => new MoveRandomly(target, waitTime, viewRadius, movement);
   }
}