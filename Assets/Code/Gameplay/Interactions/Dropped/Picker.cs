using Extensions;
using UnityEngine;

namespace Interactions.Items {
   public class Picker : MonoBehaviour {
      [field: SerializeField] public Entity    Owner { get; set; }
      public                         LayerMask layerMask;
      public                         float     pickRadius = 1f;

      [Min(0f)] public float duration = 1f;



      private void Update() {
         foreach (Collider2D item in Physics2D.OverlapCircleAll(transform.Position2D(), pickRadius, layerMask))
            if (item.TryGetComponent(out Dropped dropped)
             && dropped.enabled
             && dropped.Compatible(Owner))
               dropped.Pick(Owner, duration);
      }



      private void OnDrawGizmos() {
         UGizmos.DrawFilledSphere(pickRadius, transform.position);
      }
   }
}