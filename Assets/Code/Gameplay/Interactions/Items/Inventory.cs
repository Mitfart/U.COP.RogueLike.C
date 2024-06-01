using System.Collections.Generic;
using UnityEngine;

namespace Interactions.Items {
   public class Inventory : MonoBehaviour {
      public Entity owner;

      [SerializeField] private List<Item> items = new();



      private void Awake() {
         foreach (Item item in items) {
            item.Apply(owner);
         }
      }



      public void Pick(Item item) {
         items.Add(item);
         item.Apply(owner);
      }

      public void Drop(Item item) {
         items.Remove(item);
         item.Revoke(owner);
      }
   }
}