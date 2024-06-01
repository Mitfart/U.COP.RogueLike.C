using Infrastructure.Services.Input;
using Movements;
using UnityEngine;
using VContainer;

namespace Units.Hero {
   public class HeroMove : MonoBehaviour {
      public Movement2D movement;

      private IInputService _input;



      [Inject] public void Construct(IInputService input) => _input = input;


      private void Update() => movement.SetDirection(_input.MoveDir);
   }
}