using Infrastructure.Services.Time;
using Units.Behavior.Components;
using Units.Behavior.Tree;
using VContainer;

namespace Units.Behavior.Nodes {
   public class ShootAtTarget : Node {
      private readonly AITarget    _target;
      private readonly WeaponOwner _weaponOwner;
      private readonly float       _prepareTime;

      private ITimeService _time;
      private float        _startTime;



      public ShootAtTarget(AITarget target, WeaponOwner weaponOwner, float prepareTime) {
         _target      = target;
         _weaponOwner = weaponOwner;
         _prepareTime = prepareTime;
      }

      [Inject] public void Inject(ITimeService time) => _time = time;

      protected override void OnBegin() => _startTime = _time.Time;

      protected override Status OnRun() {
         _weaponOwner.Aim(_target.Position);

         if (!_time.Pass(_startTime, _prepareTime))
            return Status.Run;

         _weaponOwner.Attack();
         return Status.Succes;
      }
   }
}