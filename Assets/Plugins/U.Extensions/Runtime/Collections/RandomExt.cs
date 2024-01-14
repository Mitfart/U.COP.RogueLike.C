using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RandomExt {
   public static T Random<T>(this IEnumerable<T> source, params T[] exclude) {
      List<T> collection = source as List<T> ?? source.ToList();
      collection.RemoveAll(exclude.Contains);

      return collection.Count != 0
         ? collection[collection.RandomIndex()]
         : default;
   }


   private static int RandomIndex<T>(this IReadOnlyCollection<T> source)
      => Mathf.RoundToInt(
         UnityEngine.Random.Range(
            minInclusive: 0,
            source.Count - 1
         )
      );
}