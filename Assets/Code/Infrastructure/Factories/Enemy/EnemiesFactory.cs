using System.Collections.Generic;
using Infrastructure.AssetsManagement;
using Locations;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Factories.Enemy {
   public class EnemiesFactory : Factory {
      private const string _CONTAINER_NAME = "Enemies";
      
      public readonly List<Entity> enemies = new();


      
      public EnemiesFactory(IAssets assets, IObjectResolver resolver) : base(assets, resolver) { }

      public Entity Spawn(ISpawnPoint spawnPoint) {
         Entity ins = assets.Ins<Entity>( //
            spawnPoint.Enemy,
            spawnPoint.Position,
            parent: Container(_CONTAINER_NAME, spawnPoint.Enemy.editorAsset.name)
         );
         di.InjectGameObject(ins.gameObject);

         enemies.Add(ins);
         return ins;
      }
   }
}