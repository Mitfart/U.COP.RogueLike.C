using Infrastructure.AssetsManagement;
using Infrastructure.AssetsManagement.Refs;
using Infrastructure.Factories.Enemy;
using Infrastructure.Factories.Hero;
using Infrastructure.Factories.Items;
using Infrastructure.Factories.Level;
using Infrastructure.Loading;
using Interactions.Items;
using Interactions.Level;
using Interactions.Loot;
using Locations;
using Unity.VisualScripting;
using UnityEngine;

namespace Infrastructure.GameSM.States {
   public class LoadLevelState : GameState<LoadData> {
      private readonly ILoadingCurtain _loading;
      private readonly Level           _level;
      private readonly IAssets         _assets;
      private readonly EnemiesFactory  _enemiesFactory;
      private readonly LevelFactory    _levelFactory;
      private readonly HeroFactory     _heroFactory;
      private readonly ItemsFactory    _itemsFactory;


      public LoadLevelState(
         GameStateMachine gameStateMachine,
         ILoadingCurtain  loading,
         Level            level,
         IAssets          assets,
         EnemiesFactory   enemiesFactory,
         LevelFactory     levelFactory,
         HeroFactory      heroFactory,
         ItemsFactory     itemsFactory
      ) : base(gameStateMachine) {
         _loading        = loading;
         _level          = level;
         _assets         = assets;
         _enemiesFactory = enemiesFactory;
         _levelFactory   = levelFactory;
         _heroFactory    = heroFactory;
         _itemsFactory   = itemsFactory;
      }



      public override async void Enter(LoadData loadData) {
         await _loading.Begin();

         if (!_level.Room.IsUnityNull())
            UnloadPrevRoom();

         AssetComponentRef<Room> roomAsset = loadData.location.Rooms[loadData.roomId];
         IRoom                   roomIns   = await _assets.InsAsync<IRoom>(roomAsset);

         _level.SetRoom(loadData.roomId, roomIns);

         SpawnDoors(roomIns);
         SpawnTreasures(roomIns);
         SpawnEnemies(roomIns);
         SpawnPlayer(roomIns);

         await _loading.End();

         await _heroFactory.Hero.animator.EnterRoom();

         StateMachine.Enter<GameplayState>();
      }



      private void SpawnDoors(IRoom room) {
         if (_levelFactory.doors.Count > 0) {
            foreach (Door door in _levelFactory.doors) {
               if (!door.IsUnityNull() && !door.gameObject.IsUnityNull())
                  Object.Destroy(door.gameObject);
            }

            _levelFactory.doors.Clear();
         }

         foreach (Vector3 exitPoint in room.ExitPoints) {
            int nextRoomId = _level.RoomID + 1;

            if (nextRoomId >= _level.Location.Rooms.Count)
               nextRoomId = 0;

            _levelFactory.SpawnDoor(exitPoint, _level.Location, nextRoomId);
         }
      }

      private void SpawnTreasures(IRoom room) {
         if (_levelFactory.treasures.Count > 0) {
            foreach (Treasure treasure in _levelFactory.treasures) {
               if (!treasure.IsUnityNull() && !treasure.gameObject.IsUnityNull())
                  Object.Destroy(treasure.gameObject);
            }

            _levelFactory.treasures.Clear();
         }

         foreach (ITreasurePoint treasurePoint in room.TreasurePoints)
            _levelFactory.SpawnTreasure(treasurePoint.Position, treasurePoint.TreasureSize);
      }

      private void SpawnEnemies(IRoom room) {
         if (_enemiesFactory.enemies.Count > 0) {
            foreach (Entity enemy in _enemiesFactory.enemies) {
               if (!enemy.IsUnityNull() && !enemy.gameObject.IsUnityNull())
                  Object.Destroy(enemy.gameObject);
            }

            _enemiesFactory.enemies.Clear();
         }

         foreach (ISpawnPoint spawnPoint in room.SpawnPoints)
            _enemiesFactory.Spawn(spawnPoint);
      }

      private void SpawnPlayer(IRoom roomIns) {
         _heroFactory.Spawn(roomIns.EnterPoint);
      }



      private void UnloadPrevRoom() {
         _level.Room.DestroySelf();

         foreach (DroppedItem droppedItem in _itemsFactory.itemsOnGround)
            Object.Destroy(droppedItem.gameObject);

         _itemsFactory.itemsOnGround.Clear();
      }
   }

   public struct LoadData {
      public readonly Location location;
      public readonly int      roomId;

      public LoadData(Location loc, int id) {
         location = loc;
         roomId   = id;
      }
   }
}