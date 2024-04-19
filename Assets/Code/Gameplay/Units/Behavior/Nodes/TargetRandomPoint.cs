using Infrastructure.Services.Random;
using Units.Behavior.Components;
using Units.Behavior.Tree;
using VContainer;

namespace Units.Behavior.Nodes {
   internal class TargetRandomPoint : Node {
      private readonly AITarget _target;
      private readonly float    _radius;

      private IRandomService _random;



      public TargetRandomPoint(AITarget target, float radius) {
         _target = target;
         _radius = radius;
      }

      [Inject]
      public void Inject(IRandomService random) {
         _random = random;
      }

      protected override void OnBegin() => ChooseRandomPoint();

      private void ChooseRandomPoint() => _target.Set(Entity.Position + _random.InsideCircle(_radius));
   }
}