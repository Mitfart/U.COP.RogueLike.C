using System;
using UnityEngine;

public static class NaPhysics2D {
   private const int _START_SIZE = 16;

   private static Collider2D[] _Results = new Collider2D[_START_SIZE];



   public static void ForAllInCircle(Action<Collider2D> action, Vector2 origin, float radius, int layerMask) {
      int size = Physics2D.OverlapCircleNonAlloc(
         origin, //
         radius,
         _Results,
         layerMask
      );

      ResizeForFill(size);
      Do(action, size);
   }



   private static void Do(Action<Collider2D> action, int @for) {
      for (var i = 0; i < @for; i++)
         action?.Invoke(_Results[i]);
   }

   private static void ResizeForFill(int size) {
      while (size >= _Results.Length)
         Array.Resize(ref _Results, _Results.Length * 2);
   }
}