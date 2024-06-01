using System;
using System.Threading.Tasks;
using Battle.HitBoxes.Receiver.Hurt;
using Battle.Weapons.Attacks;
using EasyButtons;
using Infrastructure.Services.Time;
using Structs.Optional;
using UnityEngine;
using VContainer;

namespace Battle.Weapons {
   public class Weapon : MonoBehaviour {
      public event Action OnBeginAttack;
      public event Action OnEndAttack;

      public Sprite          sprite;
      public WeaponAttack    attackMethod;
      public HurtReceiver    receiver;
      public float           baseDamage       = 1f;
      public Optional<float> damageMultiplier = new(startValue: 1f);
      public float           reloadDuration;

      private bool _blocked;

      public WeaponReloading Reloading { get; private set; }

      public float Damage => damageMultiplier.enabled ? baseDamage * damageMultiplier.value : baseDamage;



      [Inject] public void Construct(ITimeService timeService) => Reloading = new WeaponReloading(this, timeService);



      [Button(Mode = ButtonMode.EnabledInPlayMode)]
      public async Task Attack() {
         if (!_blocked) {
            OnBeginAttack?.Invoke();

            await attackMethod.Perform(this);

            OnEndAttack?.Invoke();
            Reloading.Reload();
         }
      }

      [Button(Mode = ButtonMode.EnabledInPlayMode)] public void Block() => _blocked = true;
      [Button(Mode = ButtonMode.EnabledInPlayMode)] public void Unblock() => _blocked = false;
   }
}