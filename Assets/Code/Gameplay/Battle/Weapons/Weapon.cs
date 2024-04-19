using System;
using System.Threading.Tasks;
using Battle.HitBoxes.Receiver.Hurt;
using Battle.Weapons.Attacks;
using EasyButtons;
using Infrastructure.Services.Time;
using UnityEngine;
using VContainer;

namespace Battle.Weapons {
   public class Weapon : MonoBehaviour {
      public event Action OnBeginAttack;
      public event Action OnEndAttack;

      [field: SerializeField] public WeaponAttack AttackMethod { get; private set; }

      [field: SerializeField]          public HurtReceiver Receiver       { get; private set; }
      [Min(0)] [field: SerializeField] public float        ReloadDuration { get; private set; }

      public bool            Blocked   { get; private set; }
      public WeaponReloading Reloading { get; private set; }



      [Inject]
      public void Construct(ITimeService timeService) {
         Reloading = new WeaponReloading(this, timeService);
      }



      [Button(Mode = ButtonMode.EnabledInPlayMode)]
      public async Task Attack() {
         if (!Blocked) {
            OnBeginAttack?.Invoke();

            AttackMethod.Perform(this);

            OnEndAttack?.Invoke();
            Reloading.Reload();
         }
      }

      [Button(Mode = ButtonMode.EnabledInPlayMode)]
      public void Block() {
         Blocked = true;
      }

      [Button(Mode = ButtonMode.EnabledInPlayMode)]
      public void Unblock() {
         Blocked = false;
      }
   }
}