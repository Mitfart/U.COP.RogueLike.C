using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Envirenment.Interactions {
   public class Interactor : MonoBehaviour {
      [Min(0)] public float     radius;
      public          LayerMask mask;

      public event Action<Interactable> OnHover;
      public event Action<Interactable> OnUnhover;
      public event Action<Interactable> OnInteract;

      public bool         Hovering            { get; private set; }
      public Interactable HoveredInteractable { get; private set; }



      private void Update() {
         TryHover(GetClosestInteractable());
      }



      private void OnDrawGizmos() {
         Gizmos.color = Color.cyan;
         Gizmos.DrawWireSphere(transform.position, radius);
      }



      public void Interact() {
         if (!Hovering)
            return;

         HoveredInteractable.Interact();
         OnInteract?.Invoke(HoveredInteractable);
      }



      private Interactable GetClosestInteractable() {
         Interactable closest         = null;
         var          closestDistance = float.MaxValue;

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



      private void TryHover(Interactable interactable) {
         if (Hovered(interactable))
            return;

         if (Hovering)
            Unhover(HoveredInteractable);

         if (!interactable.IsUnityNull())
            Hover(interactable);


         void Unhover(Interactable interactable) {
            interactable.Unhover();
            OnUnhover?.Invoke(interactable);
            Hovering            = false;
            HoveredInteractable = null;
         }

         void Hover(Interactable interactable) {
            interactable.Hover();
            OnHover?.Invoke(interactable);
            Hovering            = true;
            HoveredInteractable = interactable;
         }
      }

      private bool Hovered(Interactable interactable) {
         return interactable == HoveredInteractable;
      }
   }
}