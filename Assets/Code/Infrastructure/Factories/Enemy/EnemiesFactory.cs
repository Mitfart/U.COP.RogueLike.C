using System;
using System.Collections.Generic;
using Extensions;
using Infrastructure.AssetsManagement;
using Locations;
using VContainer;

namespace Infrastructure.Factories.Enemy {
   public class EnemiesFactory : Factory {
      private const string _TAG = "Enemies";

      public event Action OnEnemyDie;
      public event Action OnAllEnemiesDies;

      public readonly List<Entity> Enemies = new();



      public EnemiesFactory(IAssets assets, IObjectResolver resolver) : base(assets, resolver) { }

      public override void Reset() {
         base.Reset();
         Enemies.CleanUp();

         OnEnemyDie       = null;
         OnAllEnemiesDies = null;
      }



      public Entity Spawn(ISpawnPoint spawnPoint) {
         Entity ins = Spawn<Entity>(spawnPoint.Enemy, Container(_TAG, spawnPoint.DebugName), spawnPoint.Position);

         if (ins.Health.enabled) {
            ins.Health.value.OnZero += RegDeath;

            void RegDeath() {
               ins.Health.value.OnZero -= RegDeath;
               RegisterDeath(ins);
            }
         }

         Enemies.Add(ins);
         return ins;
      }



      private void RegisterDeath(Entity enemy) {
         OnEnemyDie?.Invoke();

         Enemies.Remove(enemy);

         if (Enemies.Count <= 0)
            OnAllEnemiesDies?.Invoke();
      }
   }
}