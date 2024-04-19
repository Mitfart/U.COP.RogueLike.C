using Units.Behavior.Components;
using Units.Behavior.Tree;

namespace Units.Behavior.Nodes {
   public class IfHasTarget : ConditionNode {
      private readonly AITarget _target;

      public IfHasTarget(AITarget target, Node @true, Node @false) : base(@true, @false) {
         _target = target;
      }

      internal override bool Condition() => _target.HasTarget;
   }
}