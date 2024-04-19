using UnityEngine;

public class FreezeRotation : MonoBehaviour {
   private void Update() {
      transform.rotation = Quaternion.identity;
   }
}