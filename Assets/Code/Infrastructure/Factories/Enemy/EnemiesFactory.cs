using System;
using System.Collections.Generic;
using Extensions;
using Infrastructure.AssetsManagement;
using Locations;
using UnityEngine;
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



      public Entity Spawn(SpawnPoint<Entity> spawnPoint) {
         Entity ins = Spawn(spawnPoint, _TAG);
         
         ins.OnDie += RegDeath;

         Enemies.Add(ins);
         return ins;

         void RegDeath() {
            ins.OnDie -= RegDeath;
            RegisterDeath(ins);
         }
      }



      private void RegisterDeath(Entity enemy) {
         OnEnemyDie?.Invoke();

         Enemies.Remove(enemy);

         if (Enemies.Count <= 0)
            OnAllEnemiesDies?.Invoke();
      }
   }
}