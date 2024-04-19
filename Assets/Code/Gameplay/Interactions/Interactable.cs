using System;
using UnityEngine;

namespace Interactions {
   [RequireComponent(typeof(Collider2D))]
   public class Interactable : MonoBehaviour {
      public event Action<HeroInteractor> OnHover;
      public event Action<HeroInteractor> OnUnhover;
      public event Action<HeroInteractor> OnInteract;

      public void Hover(HeroInteractor    interactor) => OnHover?.Invoke(interactor);
      public void Unhover(HeroInteractor  interactor) => OnUnhover?.Invoke(interactor);
      public void Interact(HeroInteractor interactor) => OnInteract?.Invoke(interactor);
   }
}