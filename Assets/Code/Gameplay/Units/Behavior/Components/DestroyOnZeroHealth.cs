using UnityEngine;

namespace Units.Behavior.Components {
   public class DestroyOnZeroHealth : MonoBehaviour {
      public Entity entity;
      public Health health;

      private void OnEnable()  => health.OnZero += entity.Die;
      private void OnDisable() => health.OnZero -= entity.Die;
   }
}