using UnityEngine;
using UnityEngine.Events;

namespace Battle.Special {
   [RequireComponent(typeof(Explosion))]
   public class UEventsExplosion : MonoBehaviour {
      public UnityEvent begin;
      public UnityEvent end;

      private Explosion _explosion;



      private void Awake() => _explosion = GetComponent<Explosion>();

      private void OnEnable() {
         _explosion.OnBegin += begin.Invoke;
         _explosion.OnEnd   += end.Invoke;
      }

      private void OnDisable() {
         _explosion.OnBegin -= begin.Invoke;
         _explosion.OnEnd   -= end.Invoke;
      }
   }
}