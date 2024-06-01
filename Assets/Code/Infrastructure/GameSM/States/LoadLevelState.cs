using Infrastructure.AssetsManagement.Refs;
using Infrastructure.Factories.Bullets;
using Infrastructure.Factories.Enemy;
using Infrastructure.Factories.Hero;
using Infrastructure.Factories.Items;
using Infrastructure.Factories.Level;
using Infrastructure.Factories.UI;
using Infrastructure.Loading;
using Locations;
using Units.Hero;
using UnityEngine;

namespace Infrastructure.GameSM.States {
   public class LoadLevelState : GameState<LoadData> {
      private readonly ILoadingCurtain _loading;
      private readonly Level           _level;
      private readonly EnemiesFactory  _enemiesFactory;
      private readonly LevelFactory    _levelFactory;
      private readonly HeroFactory     _heroFactory;
      private readonly ItemsFactory    _itemsFactory;
      private readonly BulletsFactory  _bulletsFactory;
      private readonly UIFactory       _uiFactory;


      public LoadLevelState(
         GameStateMachine gameStateMachine,
         ILoadingCurtain  loading,
         Level            level,
         EnemiesFactory   enemiesFactory,
         LevelFactory     levelFactory,
         HeroFactory      heroFactory,
         ItemsFactory     itemsFactory,
         BulletsFactory   bulletsFactory,
         UIFactory        uiFactory
      ) : base(gameStateMachine) {
         _loading        = loading;
         _level          = level;
         _enemiesFactory = enemiesFactory;
         _levelFactory   = levelFactory;
         _heroFactory    = heroFactory;
         _itemsFactory   = itemsFactory;
         _bulletsFactory = bulletsFactory;
         _uiFactory      = uiFactory;
      }



      public override async void Enter(LoadData loadData) {
         await _loading.Begin();

         UnloadPrevRoom();

         IRoom room = _levelFactory.SpawnRoom(loadData.RoomAsset);

         _level.SetRoom(loadData.RoomId, room);

         SpawnDoors(room);
         SpawnTreasures(room);
         SpawnEnemies(room);
         SpawnPlayer(room);

         await _loading.End();

         StateMachine.Enter<GameplayState>();

         await _heroFactory.Hero.animator.EnterRoom();
      }



      private void SpawnDoors(IRoom room) {
         foreach (Vector3 exitPoint in room.ExitPoints) {
            int nextRoomId = _level.RoomID + 1;

            _levelFactory.SpawnDoor(exitPoint, _level.Location, nextRoomId);
         }
      }

      private void SpawnTreasures(IRoom room) {
         foreach (ITreasurePoint treasurePoint in room.TreasurePoints) {
            _levelFactory.SpawnTreasure(treasurePoint.Position, treasurePoint.TreasureSize);
         }
      }

      private void SpawnEnemies(IRoom room) {
         foreach (ISpawnPoint spawnPoint in room.SpawnPoints) {
            _enemiesFactory.Spawn(spawnPoint);
         }

         if (_enemiesFactory.Enemies.Count > 0)
            _enemiesFactory.OnAllEnemiesDies += _level.InvokeClearEvent;
         else
            _level.InvokeClearEvent();
      }

      private void SpawnPlayer(IRoom roomIns) {
         Hero hero = _heroFactory.Spawn(roomIns.EnterPoint);

         _uiFactory.InsHUD(hero);
      }



      private void UnloadPrevRoom() {
         _level.Room?.DestroySelf();

         _enemiesFactory.Reset();
         _itemsFactory.Reset();
         _levelFactory.Reset();
         _bulletsFactory.Reset();
      }
   }

   public struct LoadData {
      public readonly Location Location;
      public readonly int      RoomId;

      public AssetComponentRef<Room> RoomAsset => Location.Rooms[RoomId];

      public LoadData(Location loc, int id) {
         Location = loc;
         RoomId   = id;
      }
   }
}