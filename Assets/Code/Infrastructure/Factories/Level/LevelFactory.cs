using System;
using System.Collections.Generic;
using Envirenment.Interactions.Level;
using Envirenment.Interactions.Loot;
using Envirenment.Locations;
using Infrastructure.AssetsManagement;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Treasure = Envirenment.Interactions.Loot.Treasure;

namespace Infrastructure.Factories.Level {
   public class LevelFactory : Factory {
      private const string _CONTAINER_NAME = "Level";

      public readonly List<Door>     doors     = new();
      public readonly List<Treasure> treasures = new();



      public LevelFactory(IAssets assets, IObjectResolver resolver) : base(assets, resolver) { }



      public Door SpawnDoor(Vector3 pos, Location location, int roomId) {
         Door ins = assets //
                   .Ins<Door>("DOOR", pos, parent: Container(_CONTAINER_NAME, "DOOR"))
                   .Init(location, roomId);

         di.InjectGameObject(ins.gameObject);
         doors.Add(ins);

         return ins;
      }



      public Treasure SpawnTreasure(Vector3 pos, TreasureSize treasureSize) {
         Treasure ins = treasureSize switch {
            TreasureSize.Small  => assets.Ins<Treasure>("CHEST_SM", pos, parent: Container(_CONTAINER_NAME, "CHEST")),
            TreasureSize.Normal => assets.Ins<Treasure>("CHEST_NM", pos, parent: Container(_CONTAINER_NAME, "CHEST")),
            TreasureSize.Large  => assets.Ins<Treasure>("CHEST_LG", pos, parent: Container(_CONTAINER_NAME, "CHEST")),
            _                   => throw new ArgumentOutOfRangeException(nameof(treasureSize), treasureSize, null)
         };

         di.InjectGameObject(ins.gameObject);
         treasures.Add(ins);

         return ins;
      }
   }
}