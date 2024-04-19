using Infrastructure.Services.Input;
using Interactions;
using UnityEngine;
using VContainer;

namespace Units.Hero {
   public class HeroInteract : MonoBehaviour {
      public HeroInteractor heroInteractor;

      private IInputService _input;

      

      private void Update() {
         if (_input.Interact)
            heroInteractor.Interact();
      }



      [Inject]
      public void Construct(IInputService input) {
         _input = input;
      }
   }
}