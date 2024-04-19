using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyButtons;
using Structs.Optional;
using Unity.VisualScripting;
using UnityEngine;

namespace Battle.Bullets.Spawners {
   public abstract class BulletsPattern : Spawner<Bullet> {
      public List<Spawner<Bullet>> spawners;

      public Optional<float> timeBetween;
      public bool            infiniteRepeat;
      public Optional<float> repeatDelay;



      public override async Task Spawn(Action<Bullet> onSpawnBullet) {
         do {
            await SpawnPattern(onSpawnBullet);

            if (repeatDelay.enabled)
               await Awaitable.WaitForSecondsAsync(repeatDelay.value - timeBetween.ValueOrDefault());
            else
               await Awaitable.NextFrameAsync();
         } while (infiniteRepeat);
      }

      protected abstract Task SpawnPattern(Action<Bullet> onSpawnBullet);



#if UNITY_EDITOR
      [Button]
      public void _GetSpawnersInChild() {
         spawners ??= new List<Spawner<Bullet>>();
         spawners.AddRange(GetComponentsInChildren<Spawner<Bullet>>());
         spawners = Enumerable.ToHashSet(spawners).ToList();

         for (var i = 0; i < spawners.Count; i++) {
            Spawner<Bullet> spawner = spawners[i];

            if (spawner != this && !spawner.IsUnityNull())
               continue;

            spawners.RemoveAt(i);
            i--;
         }
      }
#endif
   }
}