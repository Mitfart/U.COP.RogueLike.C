using System.Collections.Generic;
using EasyButtons;
using Infrastructure.Factories.Items;
using UnityEngine;
using VContainer;

namespace Envirenment.Interactions.Items {
   public class TEST_ITEMS_DROPPER : MonoBehaviour {
      public                       List<Item> items;


      private ItemsFactory _itemsFactory;



      [Inject]
      public void Construct(ItemsFactory itemsFactory) {
         _itemsFactory = itemsFactory;
      }



      [Button(Mode = ButtonMode.EnabledInPlayMode)]
      public async void Drop() {
      }
   }
}