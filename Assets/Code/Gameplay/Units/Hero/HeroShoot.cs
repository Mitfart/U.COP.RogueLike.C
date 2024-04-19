using Infrastructure.Services.Input;
using UnityEngine;
using VContainer;

namespace Units.Hero {
   public class HeroShoot : MonoBehaviour {
      public  WeaponOwner   weaponOwner;
      private IInputService _input;


      private void Update() {
         if (_input.Attack)
            weaponOwner.Attack();
      }



      [Inject]
      public void Construct(IInputService input) {
         _input = input;
      }
   }
}