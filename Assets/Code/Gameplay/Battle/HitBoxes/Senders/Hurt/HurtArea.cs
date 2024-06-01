using System.Collections.Generic;
using Battle.HitBoxes.Receiver.Hurt;
using Battle.HitBoxes.Senders.Hit;
using Structs.Optional;
using Unity.VisualScripting;
using UnityEngine;

namespace Battle.HitBoxes.Senders.Hurt {
   [DisallowMultipleComponent]
   public abstract class HurtArea : HitDataSender<HurtArea, HurtReceiver> {
      public Direction direction = Direction.Up;

      [Min(min: 0f)] public float           baseDamage       = 1f;
      public                Optional<float> damageMultiplier = new(startValue: 1f);

      protected LayerMask Layers { get; private set; }



      private void Awake()       => Layers = LayerMask.GetMask("Default", "Environment");
      private void FixedUpdate() => CheckHit();



      protected abstract IEnumerable<RaycastHit2D> Cast();
      protected abstract void                      DrawGizmos();



      private void CheckHit() {
         IEnumerable<RaycastHit2D> hits = Cast();

         foreach (RaycastHit2D hit in hits) {
            if (!IsHitable(hit, out HitArea hitArea))
               continue;

            HitData hitData = CreateHitData(hit, hitArea);

            hitArea.Send(hitData);
            Send(hitData);
         }
      }

      private bool IsHitable(RaycastHit2D hit, out HitArea hitArea) {
         hitArea = null;
         return !Owner.IsUnityNull()
             && !hit.collider.IsUnityNull()
             && !hit.collider.gameObject.IsUnityNull()
             && hit.collider.TryGetComponent(out hitArea)
             && !hitArea.Owner.IsUnityNull()
             && !hitArea.Owner.Invulnerable
             && hitArea.Owner      != Owner
             && hitArea.Owner.Team != Owner.Team;
      }

      private HitData CreateHitData(RaycastHit2D hit, HitArea hitArea)
         => new(
            Owner,
            hitArea.Owner,
            damageMultiplier.enabled //
               ? baseDamage * damageMultiplier.value
               : baseDamage,
            hit
         );



      private void OnDrawGizmos() {
         Gizmos.color = Color.red;

         DrawGizmos();
         DrawDirection();
      }

      private void DrawDirection() {
         Transform self   = transform;
         Vector2   origin = self.Position2D();
         Vector2   dir    = self.GetDirection(direction);
         Gizmos.DrawLine(origin, origin + dir);
      }
   }
}