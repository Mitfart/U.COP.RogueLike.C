using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Gameplay.Bullets.Spawners {
   public class ParallelBulletsPattern : BulletsPattern {
      private Task[] _tasks;



      private void Awake() {
         _tasks = new Task[spawners.Count];
      }

      protected override async Task SpawnPattern(Action<Bullet> onSpawnBullet) {
#if UNITY_EDITOR
         if (spawners.Count > _tasks.Length)
            Array.Resize(ref _tasks, spawners.Count);
#endif
         
         for (var i = 0; i < spawners.Count; i++) {
            _tasks[i] = spawners[i].Spawn(onSpawnBullet);

            if (timeBetween.enabled)
               await Awaitable.WaitForSecondsAsync(timeBetween.value);
         }

         await Task.WhenAll(_tasks);
      }
   }
}