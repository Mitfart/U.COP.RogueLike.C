using Gameplay.Battle.Areas.Hit;
using Gameplay.Battle.Areas.Hurt;
using UnityEngine;

namespace Gameplay.Battle {
   public readonly struct HitData {
      private readonly RaycastHit2D _data;
      private readonly HurtArea     _hurtArea;
      private readonly HitArea      _hitArea;

      public Vector2 Point  => _data.point;
      public Vector2 Normal => _data.normal;

      public Entity Dealer => _hurtArea.Receiver.Owner;
      public Entity Taker  => _hitArea.Receiver.Owner;
      


      public HitData(
         RaycastHit2D hitData,
         HurtArea     hurtArea,
         HitArea      hitArea
      ) {
         _data     = hitData;
         _hurtArea = hurtArea;
         _hitArea  = hitArea;
      }



      public override string ToString() => $"[Hit] {Dealer.name} >>> {Taker.name} - [Point: {Point} | Normal: {Normal}]";
   }
}