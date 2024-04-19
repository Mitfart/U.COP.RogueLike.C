using System.Collections.Generic;
using Envirenment.Interactions.Items;
using UnityEngine;

namespace Envirenment.Interactions.Loot {
   [CreateAssetMenu(menuName = "item/new LootBag")]
   public class LootBag : ScriptableObject {
      [SerializeField] private List<Item> items;

      public Item GetRandom() => items[Random.Range(0, items.Count)];
   }
}