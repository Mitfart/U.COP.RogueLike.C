using Infrastructure.Services.Time;
using UnityEngine;
using VContainer;

namespace Movements {
   public abstract class Movement2D : MonoBehaviour {
      protected                      ITimeService Time;
      [field: SerializeField] public float        Speed { get; private set; }

      public Vector2 Destination { get; private set; }

      public virtual Vector2 Direction => (Destination - transform.Position2D()).normalized;
      public virtual Vector2 Velocity  => Direction * Speed;

      [Inject] public void Construct(ITimeService timeService) => Time = timeService;



      protected virtual void Awake() {
         SetDestination(transform.Position2D());
         SetSpeed(Speed);
      }



      public virtual void SetSpeed(float         value)       => Speed = value;
      public virtual void SetDestination(Vector2 destination) => Destination = destination;
      public virtual void SetDirection(Vector2   dir)         => Destination = transform.Position2D() + dir;

      public virtual bool AtDestination()
         => (Destination - transform.Position2D()).sqrMagnitude
         <= Velocity.sqrMagnitude * Time.Delta + Consts.EPSILON;
   }
}