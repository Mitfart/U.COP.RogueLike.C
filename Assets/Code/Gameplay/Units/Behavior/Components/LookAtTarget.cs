using UnityEngine;

namespace Units.Behavior.Components {
   public class LookAtTarget : MonoBehaviour {
      public View     view;
      public AITarget aiTarget;

      private void Update() {
         view.LookAt(aiTarget.Position);
      }
   }
}