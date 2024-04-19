using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Battle.Bullets.Spawners {
   public class SequenceBulletsPattern : BulletsPattern {
      protected override async Task SpawnPattern(Action<Bullet> onSpawnBullet) {
         foreach (Spawner<Bullet> t in spawners) {
            await t.Spawn(onSpawnBullet);

            if (timeBetween.enabled)
               await Awaitable.WaitForSecondsAsync(timeBetween.value);
         }
      }
   }
}