using Infrastructure.Services.Input;
using UnityEngine;
using VContainer;

namespace Units.Hero {
   public class HeroAim : MonoBehaviour {
      public View view;

      private IInputService _input;



      [Inject] public void Construct(IInputService input) => _input = input;


      private void Update() => view.LookAt(_input.AimPos);
   }
}