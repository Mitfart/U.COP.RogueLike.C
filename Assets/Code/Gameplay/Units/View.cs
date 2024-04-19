using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Units {
   public class View : MonoBehaviour {
      public event Action<Vector2> OnChangeDirection;
      public event Action<Vector2> OnChangePoint;

      public Entity entity;

      public Vector2 Direction { get; private set; }
      public Vector2 Point     { get; private set; }



      private void OnDrawGizmosSelected() {
         if (entity.IsUnityNull())
            return;

         Vector3 origin = entity.Position;

         Gizmos.color = Color.cyan;
         Gizmos.DrawLine(origin, origin + (Vector3)Direction);
      }



      public void LookIn(Vector2 dir) {
         dir.Normalize();
         LookAt(entity.Position + dir);
      }

      public void LookAt(Vector2 at) {
         Point     = at;
         Direction = (at - entity.Position).normalized;

         OnChangeDirection?.Invoke(Direction);
         OnChangePoint?.Invoke(Point);
      }
   }
}