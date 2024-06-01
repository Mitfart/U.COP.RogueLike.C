using UnityEngine;

namespace Interactions.Level {
   public class DoorAnimator : MonoBehaviour {
      private static readonly int _IsOpen = Animator.StringToHash(name: "IsOpen");

      public Animator animator;

      public void Lock()   => animator.SetBool(_IsOpen, value: false);
      public void Unlock() => animator.SetBool(_IsOpen, value: true);
   }
}