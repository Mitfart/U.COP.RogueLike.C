using Infrastructure.Services.Random;
using Infrastructure.Services.Time;
using Units.Behavior.Tree;
using UnityEngine;
using VContainer;

namespace Units.Behavior.Nodes {
   internal class Wait : Node {
      private readonly Vector2 _rangedDuration;

      private ITimeService _time;

      private float          _startTime;
      private float          _duration;
      private IRandomService _randomService;



      public Wait(float duration) {
         _rangedDuration = Vector2.one * duration;
      }

      public Wait(Vector2 rangedDuration) {
         _rangedDuration = rangedDuration;
      }

      [Inject]
      public void Inject(ITimeService time, IRandomService randomService) {
         _randomService = randomService;
         _time          = time;
      }

      protected override void OnBegin() {
         _startTime = _time.Time;
         _duration  = _randomService.Range(_rangedDuration.x, _rangedDuration.y);
      }

      protected override Status OnRun() => _time.Pass(_startTime, _duration) ? Status.Succes : Status.Run;
   }
}