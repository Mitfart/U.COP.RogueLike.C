using System;
using UnityEngine;

namespace Gameplay.Unit {
   public class View : MonoBehaviour {
      public event Action<Vector2> OnChangeDirection;
      public event Action<Vector2> OnChangePoint;

      public Vector2 Direction { get; private set; }
      public Vector2 Point     { get; private set; }



      private void OnDrawGizmosSelected() {
         Vector3 origin = transform.position;

         Gizmos.color = Color.cyan;
         Gizmos.DrawLine(origin, origin + (Vector3)Direction);
      }



      public void LookIn(Vector2 dir) {
         dir.Normalize();
         LookAt(transform.Position2D() + dir);
      }

      public void LookAt(Vector2 at) {
         Point     = at;
         Direction = (at - transform.Position2D()).normalized;

         OnChangeDirection?.Invoke(Direction);
         OnChangePoint?.Invoke(Point);
      }
   }
}