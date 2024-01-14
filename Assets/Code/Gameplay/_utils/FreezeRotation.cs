using UnityEngine;

namespace Gameplay {
   public class FreezeRotation : MonoBehaviour {
      private void Update() => transform.rotation = Quaternion.identity;
   }
}