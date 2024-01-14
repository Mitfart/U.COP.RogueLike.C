using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace {
   public static class DoAfterExt {
      public static Coroutine DoAfter(this MonoBehaviour behaviour, Action action, float     after) => behaviour.StartCoroutine(DoAfterRoutine(action, after));
      public static Coroutine DoAfter(this MonoBehaviour behaviour, Action action, Coroutine after) => behaviour.StartCoroutine(DoAfterRoutine(action, after));



      private static IEnumerator DoAfterRoutine(Action action, float after) {
         yield return new WaitForSeconds(after);

         action?.Invoke();
      }

      private static IEnumerator DoAfterRoutine(Action action, Coroutine after) {
         yield return after;

         action?.Invoke();
      }
   }
}