using UnityEngine;

namespace Movements.Input {
   public class DirectionMove : MonoBehaviour {
      public Direction  direction = Direction.Right;
      public Movement2D movement2D;

      private void Update() {
         movement2D.SetDirection(direction.AsVector());
      }
   }
}