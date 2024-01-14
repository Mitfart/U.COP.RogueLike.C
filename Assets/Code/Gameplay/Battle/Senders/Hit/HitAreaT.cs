using UnityEngine;

namespace Gameplay.Battle.Senders.Hit {
   public abstract class HitArea<TCollider> : HitArea where TCollider : Collider2D {
      [SerializeField] protected new TCollider collider;

      protected virtual void OnDrawGizmos() {
         collider ??= GetComponent<TCollider>();

         Gizmos.color = Color.green;
      }
   }
}