using Units.Behavior.Components;
using Units.Behavior.Tree;

namespace Units.Behavior.Nodes {
   public class IfTargetFar : ConditionNode {
      private readonly AITarget _target;
      private readonly float    _threshold;

      public IfTargetFar( //
         AITarget target,
         float    threshold,
         Node     @true,
         Node     @false
      ) : base(@true, @false) {
         _target    = target;
         _threshold = threshold * threshold;
      }

      internal override bool Condition() => (_target.Position - Entity.Position).sqrMagnitude >= _threshold;
   }
}