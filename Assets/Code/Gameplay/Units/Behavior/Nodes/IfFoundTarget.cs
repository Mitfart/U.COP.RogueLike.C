using Battle.HitBoxes.Senders.Hit;
using Units.Behavior.Components;
using Units.Behavior.Tree;
using UnityEngine;

namespace Units.Behavior.Nodes {
   public class IfFoundTarget : ConditionNode {
      private readonly AITarget  _target;
      private readonly float     _viewRadius;
      private readonly Team      _targetTeam;
      private readonly LayerMask _layerMask;



      public IfFoundTarget(
         AITarget  target,
         float     viewRadius,
         Team      targetTeam,
         LayerMask layerMask,
         Node      @true,
         Node      @false
      ) : base(@true, @false) {
         _target     = target;
         _viewRadius = viewRadius;
         _targetTeam = targetTeam;
         _layerMask  = layerMask;
      }

      internal override bool Condition() => _target.Set(GetClosest(Entity.Position));



      private Entity GetClosest(Vector2 to) {
         Entity closest    = null;
         float  closestDis = float.MaxValue;

         RaycastHit2D[] hits = Physics2D.CircleCastAll(
            to,
            _viewRadius,
            Entity.transform.up,
            float.Epsilon,
            _layerMask
         );

         foreach (RaycastHit2D hit in hits) {
            Collider2D target = hit.collider;

            if (!target.TryGetComponent(out HitArea hitArea)
             || hitArea.Owner      == Entity
             || hitArea.Owner.Team != _targetTeam)
               continue;

            Entity current = hitArea.Owner;
            float  dis     = Distance(current, to);

            if (dis >= closestDis)
               continue;

            closest    = current;
            closestDis = dis;
         }

         return closest;
      }

      private static float Distance(Entity current, Vector2 to) {
         return (current.Position - to).sqrMagnitude;
      }
   }
}