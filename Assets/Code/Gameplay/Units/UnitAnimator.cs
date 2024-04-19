using Movements;
using UnityEngine;

namespace Units {
   public class UnitAnimator : MonoBehaviour {
      public Animator   animator;
      public View       view;
      public Movement2D movement;

      private static readonly int View_X = Animator.StringToHash("View_X");
      private static readonly int View_Y = Animator.StringToHash("View_Y");
      private static readonly int Move   = Animator.StringToHash("Move");



      private void Update() {
         animator.SetFloat(View_X, view.Direction.x);
         animator.SetFloat(View_Y, view.Direction.y);

         animator.SetFloat(Move, Mathf.Max(Mathf.Abs(movement.Direction.x), Mathf.Abs(movement.Direction.y)));
      }
   }
}