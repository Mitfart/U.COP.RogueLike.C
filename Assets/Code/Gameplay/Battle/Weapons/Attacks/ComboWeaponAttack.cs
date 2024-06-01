using System.Threading;
using System.Threading.Tasks;
using Structs.Optional;
using UnityEngine;

namespace Battle.Weapons.Attacks {
   public class ComboWeaponAttack : CombinedWeaponAttack {
      [SerializeField] private Optional<float> resetTime;

      private int                     _currentAttackID;
      private CancellationTokenSource _resetTimer;



      public override async Task Perform(Weapon weapon) {
         await attacks[_currentAttackID].Perform(weapon);

         _currentAttackID++;

         if (_currentAttackID >= attacks.Count)
            _currentAttackID = 0;

         if (resetTime.enabled)
            StartResetTimer();
      }

      private async void StartResetTimer() {
         if (_resetTimer?.IsCancellationRequested == true)
            return;

         _resetTimer?.Cancel();
         _resetTimer?.Dispose();
         _resetTimer = new CancellationTokenSource();
         CancellationToken token = _resetTimer.Token;

         await Awaitable.WaitForSecondsAsync(resetTime.value, token);
         _currentAttackID = 0;
      }
   }
}