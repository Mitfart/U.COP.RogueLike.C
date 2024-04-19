using System;
using Infrastructure.Services.Time;
using UnityEngine;

namespace Battle.Weapons {
   public class WeaponReloading {
      public event Action        OnStart;
      public event Action        OnEnd;
      public event Action<float> OnProcess;

      private readonly Weapon       _weapon;
      private readonly ITimeService _time;

      private bool  _reloading;
      private float _startReloadTime;



      public WeaponReloading(Weapon weapon, ITimeService time) {
         _time   = time;
         _weapon = weapon;
      }



      public async void Reload() {
         StartReload();

         while (!Done()) {
            ProcessReload();
            await Awaitable.NextFrameAsync();
         }

         EndReload();
      }



      private void StartReload() {
         _startReloadTime = _time.Time;
         _weapon.Block();
         OnStart?.Invoke();
      }

      private void ProcessReload() { //
         OnProcess?.Invoke(Completion());
      }

      private void EndReload() {
         _weapon.Unblock();
         OnEnd?.Invoke();
      }

      private float Completion() {
         return _time.Elapsed(_startReloadTime) / _weapon.ReloadDuration;
      }

      private bool Done() {
         return _time.Pass(_startReloadTime, _weapon.ReloadDuration);
      }
   }
}