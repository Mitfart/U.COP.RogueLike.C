using System.Threading;
using System.Threading.Tasks;
using Structs.Optional;
using UnityEngine;

namespace Gameplay.Weapons {
   public class ComboWeaponAttack : CombinedWeaponAttack {
      [SerializeField] private Optional<float> resetTime;

      private int                     _currentAttackID;
      private CancellationTokenSource _resetTimer;



      public override async Task Perform(Weapon weapon) {
         if (++_currentAttackID >= attacks.Count)
            _currentAttackID = 0;

         await attacks[_currentAttackID].Perform(weapon);

         if (resetTime.enabled)
            StartResetTimer();
      }

      private async Task StartResetTimer() {
         if (_resetTimer?.IsCancellationRequested == true)
            return;

         _resetTimer?.Cancel();
         _resetTimer?.Dispose();
         _resetTimer = new CancellationTokenSource();
         CancellationToken token = _resetTimer.Token;

         await Awaitable.WaitForSecondsAsync(resetTime.value, token);
         _currentAttackID = 0;
         Debug.Log("Reset");
      }
   }
}