using Envirenment.Locations;
using Infrastructure.Factories.Hero;
using Infrastructure.GameSM;
using Infrastructure.GameSM.States;
using UnityEngine;
using VContainer;

namespace Envirenment.Interactions.Level {
   [RequireComponent(typeof(Interactable))]
   public class Door : MonoBehaviour {
      public Interactable interactable;
      public Transform    jumpPivot;

      private GameStateMachine _stateMachine;
      private Location         _location;
      private int              _roomId;
      private HeroFactory      _heroFactory;

      private bool _enteringRoom;

      private void OnEnable()  => interactable.OnInteract += EnterRoom;
      private void OnDisable() => interactable.OnInteract -= EnterRoom;



      [Inject]
      public void Construct(GameStateMachine stateMachine, HeroFactory heroFactory) {
         _heroFactory  = heroFactory;
         _stateMachine = stateMachine;
      }

      public Door Init(Location location, int roomId) {
         _roomId   = roomId;
         _location = location;
         return this;
      }



      private async void EnterRoom() {
         if (_enteringRoom)
            return;

         _enteringRoom = true;

         await _heroFactory.Hero.animator.ExitRoom(jumpPivot.position);
         _stateMachine.Enter<LoadLevelState, LoadData>(new LoadData(_location, _roomId));
      }
   }
}