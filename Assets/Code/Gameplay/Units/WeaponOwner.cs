using System.Threading.Tasks;
using Battle.HitBoxes.Receiver.Hurt;
using Battle.Weapons;
using Unity.VisualScripting;
using UnityEngine;

namespace Units {
   public class WeaponOwner : MonoBehaviour {
      public Entity       entity;
      public HurtReceiver hurtReceiver;

      [SerializeField] private Weapon weapon;

      public Weapon Weapon {
         get => weapon;
         set {
            if (!weapon.IsUnityNull())
               hurtReceiver.Remove(weapon.Receiver);

            weapon = value;

            if (!weapon.IsUnityNull())
               hurtReceiver.Add(weapon.Receiver);
         }
      }



      private void Awake() {
         if (!weapon.IsUnityNull())
            hurtReceiver.Add(weapon.Receiver);
      }

      private void OnEnable() {
         if (entity.View.enabled)
            entity.View.value.OnChangePoint += Aim;
      }

      private void OnDisable() {
         if (entity.View.enabled)
            entity.View.value.OnChangePoint -= Aim;
      }



      public async Task Attack() {
         await weapon.Attack();
      }



      public void Aim(Vector2 at) {
         weapon.transform.Rotate2D(at);
      }
   }
}