using System;
using Battle.HitBoxes.Receiver.Hurt;
using Battle.Weapons;
using Unity.VisualScripting;
using UnityEngine;

namespace Units {
   public class WeaponOwner : MonoBehaviour {
      public Action<Weapon> OnChangeWeapon;

      public Entity       entity;
      public HurtReceiver hurtReceiver;

      [SerializeField] private Weapon weapon;

      public Weapon Weapon {
         get => weapon;
         set {
            if (!weapon.IsUnityNull()) {
               hurtReceiver.Remove(weapon.receiver);
               Destroy(weapon.gameObject);
            }

            weapon = value;

            if (!weapon.IsUnityNull()) {
               hurtReceiver.Add(weapon.receiver);

               Transform weaponT = weapon.transform;
               weaponT.SetParent(entity.GetBody());
               weaponT.localPosition = Vector3.zero;
            }

            OnChangeWeapon?.Invoke(weapon);
         }
      }



      private void Awake() {
         if (!weapon.IsUnityNull())
            hurtReceiver.Add(weapon.receiver);
      }

      private void OnEnable()  => entity.View.Try(ev => ev.OnChangePoint += Aim);
      private void OnDisable() => entity.View.Try(ev => ev.OnChangePoint -= Aim);



      public async void Attack() {
         if (!weapon.IsUnityNull())
            await weapon.Attack();
      }



      public void Aim(Vector2 at) {
         if (!weapon.IsUnityNull())
            weapon.transform.Rotate2D(at);
      }
   }
}