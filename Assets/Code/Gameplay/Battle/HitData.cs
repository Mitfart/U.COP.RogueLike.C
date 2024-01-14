using Gameplay.Battle.Senders.Hit;
using Gameplay.Battle.Senders.Hurt;
using Unity.VisualScripting;
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



      public HitData(RaycastHit2D hitData, HurtArea hurtArea, HitArea hitArea) {
         _data     = hitData;
         _hurtArea = hurtArea;
         _hitArea  = hitArea;
      }



      public override string ToString()   => $"<b>[Hit]</b> {DealerName()} ->>>- {TakerName()} - [ Point: {Point} | Normal: {Normal} ]";
      private         string DealerName() => Dealer.IsUnityNull() ? "UNKNOWN_Dealer" : Dealer.name;
      private         string TakerName()  => Taker.IsUnityNull() ? "UNKNOWN_Taker" : Taker.name;
   }
}