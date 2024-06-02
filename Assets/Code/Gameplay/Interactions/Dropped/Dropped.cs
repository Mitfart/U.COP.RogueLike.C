using System.Threading.Tasks;
using DefaultNamespace;
using Infrastructure.Services.Time;
using UnityEngine;
using VContainer;

namespace Interactions.Items {
   public abstract class Dropped : MonoBehaviour {
      private ITimeService _timeService;



      [Inject]
      public void Construct(ITimeService timeService) {
         _timeService = timeService;
      }



      public async void Pick(Entity picker, float duration) {
         this.Off();

         PickStart(picker);
         await PickProcess_internal(picker, duration);
         PickEnd(picker);

         Destroy(gameObject);
      }

      public abstract bool Compatible(Entity picker);



      protected virtual void PickStart(Entity   picker) { }
      protected virtual void PickProcess(Entity picker) { }
      protected virtual void PickEnd(Entity     picker) { }



      private async Task PickProcess_internal(Entity picker, float duration) {
         Transform self          = transform;
         Vector2   startPosition = self.Position2D();
         float     rate          = 1f / duration;
         var       time          = 0f;

         while (time < 1f) {
            time += _timeService.Delta * rate;

            self.position = Vector2.Lerp(
               startPosition,
               picker.Position,
               time
            );

            PickProcess(picker);
            await Awaitable.EndOfFrameAsync();
         }
      }
   }
}