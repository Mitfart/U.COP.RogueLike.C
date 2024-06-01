using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Extensions {
   public static class CleanUpExt {
      public static void CleanUp<T>(this IList<T> list) where T : Component {
         if (list.Count <= 0)
            return;

         foreach (T item in list) {
            if (!item.IsUnityNull()
             && !item.gameObject.IsUnityNull())
               Object.Destroy(item.gameObject);
         }

         list.Clear();
      }


      public static void CleanUp<TKey, TItem>(this IDictionary<TKey, TItem> dict) where TItem : Component {
         if (dict.Count <= 0)
            return;

         foreach (TItem item in dict.Values) {
            if (!item.IsUnityNull()
             && !item.gameObject.IsUnityNull())
               Object.Destroy(item.gameObject);
         }

         dict.Clear();
      }
   }
}