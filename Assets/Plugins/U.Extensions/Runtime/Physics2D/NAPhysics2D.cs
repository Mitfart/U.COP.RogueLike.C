using System;
using UnityEngine;

public static class NAPhysics2D {
   private const int _START_SIZE = 16;

   private static Collider2D[] _results = new Collider2D[_START_SIZE];



   public static void ForAllInCircle(Action<Collider2D> action, Vector2 origin, float radius, int layerMask) {
      int size = Physics2D.OverlapCircleNonAlloc(origin, radius, _results, layerMask);

      ResizeForFill(size);
      Do(action, size);
   }



   private static void Do(Action<Collider2D> action, int @for) {
      for (var i = 0; i < @for; i++)
         action?.Invoke(_results[i]);
   }

   private static void ResizeForFill(int size) {
      while (size >= _results.Length)
         Array.Resize(ref _results, _results.Length * 2);
   }
}