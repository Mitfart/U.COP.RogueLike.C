using DefaultNamespace;
using Extensions;
using Infrastructure.Services.Time;
using UnityEngine;
using VContainer;

namespace Interactions.Items {
   public abstract class Dropped : MonoBehaviour {
      private ITimeService _timeService;
      private Transform    _self;



      private void Awake() {
         _self = transform;
      }

      [Inject]
      public void Construct(ITimeService timeService) {
         _timeService = timeService;
      }

      public async void Pick(Entity picker, float speed) {
         this.Off();

         PickStart(picker);

         while (!transform.AtDestination2D(picker.Position)) {
            _self.position += (Vector3)(picker.Position - _self.Position2D()).normalized * (speed * _timeService.Delta);

            PickProcess(picker);
            await Awaitable.EndOfFrameAsync();
         }

         PickEnd(picker);
         Destroy(gameObject);
      }

      public abstract bool Compatible(Entity picker);

      protected virtual void PickStart(Entity   picker) { }
      protected virtual void PickProcess(Entity picker) { }
      protected virtual void PickEnd(Entity     picker) { }
   }
}