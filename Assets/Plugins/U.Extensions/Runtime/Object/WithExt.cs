using System;

public static class WithExt {
   public static T With<T>(this T t, Action<T> action, Func<T, bool> @if = null) {
      if (@if == null || @if(t))
         action?.Invoke(t);

      return t;
   }
}