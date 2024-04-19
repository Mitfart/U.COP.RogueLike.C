using System;
using UnityEngine;

namespace Envirenment.Interactions {
   [RequireComponent(typeof(Collider2D))]
   public class Interactable : MonoBehaviour {
      public event Action OnHover;
      public event Action OnUnhover;
      public event Action OnInteract;

      public void Hover()    => OnHover?.Invoke();
      public void Unhover()  => OnUnhover?.Invoke();
      public void Interact() => OnInteract?.Invoke();
   }
}