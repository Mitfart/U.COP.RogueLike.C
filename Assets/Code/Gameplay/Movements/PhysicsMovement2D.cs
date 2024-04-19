using UnityEngine;

namespace Movements {
   public class PhysicsMovement2D : Movement2D {
      public float       acceleration;
      public float       maxAcceleration;
      public Rigidbody2D rb;

      public override Vector2 Velocity     => rb.velocity;
      private         Vector2 GoalVelocity => base.Velocity;



      private void FixedUpdate() {
         PerformMove();
      }

      public override bool AtDestination() {
         return (transform.Position2D() - Destination).sqrMagnitude
             <= Velocity.sqrMagnitude * time.FixedDelta + Consts.EPSILON;
      }



      private void PerformMove() {
         rb.AddForce(RequiredAccel());
      }

      private Vector2 RequiredAccel() {
         float   accelFactor   = AccelerationFactor();
         Vector2 nextVelocity  = NextVelocity(accelFactor);
         Vector2 requiredForce = RequiredForce(nextVelocity);

         return Clamp(requiredForce, accelFactor);
      }

      private Vector2 Clamp(Vector2 requiredForce, float accelFactor) {
         return Vector2.ClampMagnitude(requiredForce, MaxAcceleration(accelFactor));
      }

      private Vector2 NextVelocity(float accelerationFactor) {
         return Vector2.MoveTowards(Velocity, GoalVelocity, Acceleration(accelerationFactor) * time.Delta);
      }

      private Vector2 RequiredForce(Vector2 nextVelocity) {
         return (nextVelocity - Velocity) * time.ReverseDelta;
      }

      private float AccelerationFactor() {
         return 1f + Mathf.Max(-VelDot(), 0);
         // from 1 to 2 if change direction
      }

      private float VelDot() {
         return Vector2.Dot(Direction, Velocity.normalized);
      }

      private float Acceleration(float factor) {
         return acceleration * factor;
      }

      private float MaxAcceleration(float factor) {
         return maxAcceleration * factor;
      }
   }
}