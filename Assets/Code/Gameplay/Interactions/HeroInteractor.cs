using System;
using Attributes.ReadOnly;
using Units.Hero;
using Unity.VisualScripting;
using UnityEngine;

namespace Interactions {
   public class HeroInteractor : MonoBehaviour {
      public event Action<Interactable> OnHover;
      public event Action<Interactable> OnUnhover;
      public event Action<Interactable> OnInteract;

      public               Hero      hero;
      [Min(min: 0)] public float     radius;
      public               LayerMask mask;

      [field: SerializeField, ReadOnly] public Interactable HoveredInteractable { get; private set; }

      public bool Hovering => !HoveredInteractable.IsUnityNull();



      private void Update() => TryHover(GetClosestInteractable());



      private void OnDrawGizmos() {
         Gizmos.color = Color.cyan;
         Gizmos.DrawWireSphere(transform.position, radius);
      }



      public void Interact() {
         if (!Hovering)
            return;

         HoveredInteractable.Interact(this);
         OnInteract?.Invoke(HoveredInteractable);
      }



      private Interactable GetClosestInteractable() {
         Interactable closest         = null;
         float        closestDistance = float.MaxValue;

         foreach (Collider2D current in Physics2D.OverlapCircleAll(transform.Position2D(), radius, mask)) {
            float curDistance = (current.transform.position - transform.position).sqrMagnitude;

            if (curDistance >= closestDistance
             || !current.TryGetComponent(out Interactable interactable)
             || !interactable.enabled)
               continue;

            closest         = interactable;
            closestDistance = curDistance;
         }

         return closest;
      }



      private void TryHover(Interactable newInteractable) {
         if (Hovered(newInteractable))
            return;

         if (Hovering)
            Unhover(HoveredInteractable);

         if (!newInteractable.IsUnityNull())
            Hover(newInteractable);


         return;


         void Unhover(Interactable interactable) {
            interactable.Unhover(this);
            OnUnhover?.Invoke(interactable);
            HoveredInteractable = null;
         }

         void Hover(Interactable interactable) {
            interactable.Hover(this);
            OnHover?.Invoke(interactable);
            HoveredInteractable = interactable;
         }
      }

      private bool Hovered(Interactable interactable) => interactable == HoveredInteractable;
   }
}