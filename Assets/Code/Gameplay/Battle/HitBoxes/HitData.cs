using Unity.VisualScripting;
using UnityEngine;

namespace Battle.HitBoxes {
   public readonly struct HitData {
      public Vector2 Point  { get; }
      public Vector2 Normal { get; }

      public Entity Dealer { get; }
      public Entity Taker  { get; }

      public float Damage { get; }



      public HitData(Entity dealer, Entity taker, float damage, RaycastHit2D? hitData = null) {
         Dealer = dealer;
         Taker  = taker;
         Damage = damage;
         Point  = hitData?.point  ?? Taker.Position;
         Normal = hitData?.normal ?? Vector2.up;
      }



      public override string ToString()   => $"<b>[Hit]</b> {DealerName()} ->>>- {TakerName()} - [ Damage: {Damage} | Point: {Point} | Normal: {Normal} ]";
      private         string DealerName() => Dealer.IsUnityNull() ? "UNKNOWN_Dealer" : Dealer.name;
      private         string TakerName()  => Taker.IsUnityNull() ? "UNKNOWN_Taker" : Taker.name;
   }
}