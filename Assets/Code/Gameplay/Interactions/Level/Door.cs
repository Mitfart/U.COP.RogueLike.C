using DefaultNamespace;
using Infrastructure.Factories.Hero;
using Infrastructure.GameSM;
using Infrastructure.GameSM.States;
using Locations;
using UnityEngine;
using VContainer;

namespace Interactions.Level {
   [RequireComponent(typeof(Interactable))]
   public class Door : MonoBehaviour {
      public Interactable interactable;
      public Transform    jumpPivot;
      public DoorAnimator doorAnimator;

      private GameStateMachine _stateMachine;
      private Location         _location;
      private int              _roomId;
      private HeroFactory      _heroFactory;

      private bool            _enteringRoom;
      private Locations.Level _level;



      [Inject]
      public void Construct(GameStateMachine stateMachine, HeroFactory heroFactory, Locations.Level level) {
         _level        = level;
         _stateMachine = stateMachine;
         _heroFactory  = heroFactory;

         Lock();

         _level.OnClear += Unlock;
      }

      public Door Init(Location location, int roomId) {
         _location = location;
         _roomId   = roomId;
         return this;
      }
      
      private void OnEnable()  => interactable.OnInteract += EnterRoom;
      private void OnDisable() => interactable.OnInteract -= EnterRoom;



      private void Lock() {
         interactable.Off();
         doorAnimator.Lock();
      }

      private void Unlock() {
         interactable.On();
         doorAnimator.Unlock();

         _level.OnClear -= Unlock;
      }



      private async void EnterRoom(HeroInteractor _) {
         if (_enteringRoom)
            return;

         _enteringRoom = true;

         await _heroFactory.Hero.animator.ExitRoom(jumpPivot.position);

         if (_roomId < 0 || _roomId >= _level.Location.Rooms.Count)
            _stateMachine.Enter<EndGameState, bool>(true);
         else
            _stateMachine.Enter<LoadLevelState, LoadData>(new LoadData(_location, _roomId));
      }
   }
}