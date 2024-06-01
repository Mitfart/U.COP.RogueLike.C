using System.Collections.Generic;
using Interactions.Items;
using UnityEngine;

namespace Interactions.Loot {
   [CreateAssetMenu(menuName = "item/new LootBag")]
   public class LootBag : ScriptableObject {
      [SerializeField] private List<Item> items;

      public Item GetRandom() => items[Random.Range(minInclusive: 0, items.Count)];
   }
}