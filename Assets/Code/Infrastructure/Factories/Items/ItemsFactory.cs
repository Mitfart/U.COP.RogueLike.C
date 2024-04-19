using System.Collections.Generic;
using Envirenment.Interactions.Items;
using Infrastructure.AssetsManagement;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Factories.Items {
   public class ItemsFactory : Factory {
      private const string _CONTAINER_NAME = "Items";

      public readonly List<DroppedItem> itemsOnGround = new();



      public ItemsFactory(IAssets assets, IObjectResolver di) : base(assets, di) { }

      public DroppedItem DropItem(Item item, Vector3 pos) {
         DroppedItem ins = assets.Ins<DroppedItem>( //
            "DROPPED_ITEM",
            pos,
            parent: Container(_CONTAINER_NAME)
         );
         di.InjectGameObject(ins.gameObject);

         ins.item = item;

         itemsOnGround.Add(ins);
         ins.interactable.OnInteract += () => itemsOnGround.Remove(ins);

         return ins;
      }
   }
}