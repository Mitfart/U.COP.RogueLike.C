using Movements;
using UnityEngine;

namespace Units {
   public class UnitAnimator : MonoBehaviour {
      private static readonly int        _ViewX = Animator.StringToHash(name: "View_X");
      private static readonly int        _ViewY = Animator.StringToHash(name: "View_Y");
      private static readonly int        _Move   = Animator.StringToHash(name: "Move");
      public                  Animator   animator;
      public                  View       view;
      public                  Movement2D movement;



      private void Update() {
         animator.SetFloat(_ViewX, view.Direction.x);
         animator.SetFloat(_ViewY, view.Direction.y);

         animator.SetFloat(_Move, Mathf.Max(Mathf.Abs(movement.Direction.x), Mathf.Abs(movement.Direction.y)));
      }
   }
}