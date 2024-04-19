using Envirenment.Interactions;
using Infrastructure.Services.Input;
using UnityEngine;
using VContainer;

namespace Units.Hero {
   public class HeroInteract : MonoBehaviour {
      public Interactor interactor;

      private IInputService _input;

      

      private void Update() {
         if (_input.Interact)
            interactor.Interact();
      }



      [Inject]
      public void Construct(IInputService input) {
         _input = input;
      }
   }
}