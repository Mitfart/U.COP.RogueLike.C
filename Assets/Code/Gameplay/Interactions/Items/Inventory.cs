using System.Collections.Generic;
using UnityEngine;

namespace Envirenment.Interactions.Items {
   public class Inventory : MonoBehaviour {
      public Entity owner;

      [SerializeField] private List<Item> _items = new();

      private void Awake() {
         foreach (Item item in _items)
            item.Apply(owner);
      }

      public void Pick(Item item) {
         _items.Add(item);
         item.Apply(owner);
      }

      public void Drop(Item item) {
         _items.Remove(item);
         item.Revoke(owner);
      }
   }
}