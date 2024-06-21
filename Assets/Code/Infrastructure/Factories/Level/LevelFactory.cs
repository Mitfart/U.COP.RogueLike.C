using System.Collections.Generic;
using Extensions;
using Infrastructure.AssetsManagement;
using Interactions.Level;
using Interactions.Loot;
using Locations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Factories.Level {
   public class LevelFactory : Factory {
      private const string _TAG = "Level";

      public readonly List<Door>     Doors     = new();
      public readonly List<Treasure> Treasures = new();



      public LevelFactory(IAssets assets, IObjectResolver resolver) : base(assets, resolver) { }

      public override void Reset() {
         base.Reset();
         Doors.CleanUp();
         Treasures.CleanUp();
      }



      public IRoom SpawnRoom(object key) {
         Room ins = Spawn<Room>(key, Container(_TAG, key: "DOOR"));
         return ins;
      }

      public Door SpawnDoor(Vector3 pos, Location location, int roomId) {
         Door ins = Spawn<Door>(key: "DOOR", Container(_TAG, key: "DOOR"), pos)
           .Init(location, roomId);

         Doors.Add(ins);
         return ins;
      }



      public Treasure SpawnTreasure(SpawnPoint<Treasure> treasurePoint) {
         Treasure ins = Spawn(treasurePoint, _TAG);

         Di.InjectGameObject(ins.gameObject);
         Treasures.Add(ins);

         return ins;
      }
   }
}