using System.Collections.Generic;
using Extensions;
using Infrastructure.AssetsManagement;
using Interactions.Items;
using UnityEngine;
using VContainer;

namespace Infrastructure.Factories.Items {
   public class ItemsFactory : Factory {
      private const string _TAG           = "DROPPED";
      private const string _DROPPED_ITEM  = "DROPPED_ITEM";
      private const string _DROPPED_HEART = "DROPPED_HEART";

      public readonly List<DroppedItem>  DroppedItems  = new();
      public readonly List<DroppedHeart> DroppedHearts = new();



      public ItemsFactory(IAssets assets, IObjectResolver di) : base(assets, di) { }

      public override void Reset() {
         base.Reset();
         DroppedItems.CleanUp();
         DroppedHearts.CleanUp();
      }



      public DroppedItem DropItem(Item item, Vector3 at) {
         DroppedItem ins = Spawn<DroppedItem>(_DROPPED_ITEM, Container(_TAG), at);
         DroppedItems.Add(ins);
         ins.item = item;
         return ins;
      }

      public DroppedHeart DropHeart(Vector3 at) {
         DroppedHeart ins = Spawn<DroppedHeart>(_DROPPED_HEART, Container(_TAG), at);
         DroppedHearts.Add(ins);
         return ins;
      }
   }
}