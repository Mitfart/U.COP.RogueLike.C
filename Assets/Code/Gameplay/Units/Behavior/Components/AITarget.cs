using Unity.VisualScripting;
using UnityEngine;

namespace Units.Behavior.Components {
   [RequireComponent(typeof(View))]
   public class AITarget : MonoBehaviour {
      private Entity _target;

      public Vector2 Position => HasTarget ? TargetPosition : Point;

      public Vector2 TargetPosition => _target.Position;
      public Vector2 Point          { get; private set; }

      public bool HasTarget => !_target.IsUnityNull();



      public bool Set(Entity entity) {
         _target = entity;
         return HasTarget;
      }

      public void Set(Vector2 point) {
         Point = point;
      }
   }
}