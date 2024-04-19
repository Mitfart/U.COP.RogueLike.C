using UnityEngine;

public class Invertible : MonoBehaviour {
   public Transform body;
   public Direction direction = Direction.Right;



   private void Update() {
      CheckRotation();
   }



   private void CheckRotation() {
      Vector3 scale = body.localScale;
      scale.y         = Mathf.Sign(Projection());
      body.localScale = scale;
   }

   private float Projection() {
      return Vector2.Dot(
         direction.AsVector(), //
         body.right
      );
   }
}