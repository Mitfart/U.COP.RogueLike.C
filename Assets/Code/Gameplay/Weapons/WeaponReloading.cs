using System;
using System.Collections;
using Infrastructure.Services.Time;
using UnityEngine;
using VContainer;

namespace Gameplay.Weapons {
   public class WeaponReloading : MonoBehaviour {
      public event Action        OnStart;
      public event Action        OnEnd;
      public event Action<float> OnProcess;

      public Weapon weapon;
      public float  duration;

      private ITimeService _time;
      private bool         _reloading;
      private float        _startReloadTime;



      private void OnEnable() {
         weapon.OnEndAttack += Reload;
      }

      private void OnDisable() {
         weapon.OnEndAttack -= Reload;
      }



      [Inject]
      public void Construct(ITimeService time) {
         _time = time;
      }



      private void Reload() => StartCoroutine(ReloadRoutine());

      private IEnumerator ReloadRoutine() {
         StartReload();

         while (!Done()) {
            ProcessReload();
            yield return null;
         }

         EndReload();
      }

      private void StartReload() {
         _startReloadTime = _time.Time;
         weapon.Block();
         OnStart?.Invoke();
      }

      private void ProcessReload() {
         OnProcess?.Invoke(Completion());
      }

      private void EndReload() {
         weapon.Unblock();
         OnEnd?.Invoke();
      }

      private float Completion() => _time.Elapsed(_startReloadTime) / duration;
      private bool  Done()       => _time.Pass(_startReloadTime, duration);
   }
}