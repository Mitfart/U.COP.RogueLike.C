using Infrastructure.Services.Time;
using UnityEngine;
using VContainer;

namespace Movements {
   public abstract class Movement2D : MonoBehaviour {
      [field: SerializeField] public float Speed { get; private set; }

      protected ITimeService time;

      public Vector2 Destination { get; private set; }

      public virtual Vector2 Direction => (Destination - transform.Position2D()).normalized;
      public virtual Vector2 Velocity  => Direction * Speed;

      public virtual void SetSpeed(float value) {
         Speed = value;
      }

      
      
      protected virtual void Awake() {
         SetDestination(transform.Position2D());
         SetSpeed(Speed);
      }

      [Inject]
      public void Construct(ITimeService timeService) {
         time = timeService;
      }



      public virtual bool AtDestination() {
         return (Destination - transform.Position2D()).sqrMagnitude
             <= Velocity.sqrMagnitude * time.Delta + Consts.EPSILON;
      }


      public virtual void SetDestination(Vector2 destination) => Destination = destination;
      public virtual void SetDirection(Vector2   dir)         => Destination = transform.Position2D() + dir;
   }
}