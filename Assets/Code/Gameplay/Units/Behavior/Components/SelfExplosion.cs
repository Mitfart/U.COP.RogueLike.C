using Battle.Special;
using DefaultNamespace;
using Units.Behavior.Concrete;
using UnityEngine;

namespace Units.Behavior.Components {
   public class SelfExplosion : MonoBehaviour {
      public Entity    entity;
      public Explosion explosion;
      public AIBrain   aiBrain;
      public Transform view;

      public async void Explode() {
         view.gameObject.SetActive(value: false);

         aiBrain.Off();
         await explosion.Explode();
         entity.Die();
      }
   }
}