using Movements;
using Units.Behavior.Components;
using Units.Behavior.Tree;
using UnityEngine;

namespace Units.Behavior.Nodes {
   public class MoveRandomly : SequenceNode {
      public MoveRandomly(AITarget target, Vector2 waitTime, float radius, Movement2D movement) : base( //
         new Wait(waitTime),
         new TargetRandomPoint(target, radius),
         new MoveToTarget(target, movement, ignoreEntity: true)
      ) { }
   }
}