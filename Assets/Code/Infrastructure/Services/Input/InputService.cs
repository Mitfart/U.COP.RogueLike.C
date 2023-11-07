using System;
using Infrastructure.Render;
using UnityEngine;
using VContainer.Unity;

namespace Infrastructure.Services.Input {
   public class InputService : IInputService, IDisposable, ITickable {
      private readonly IRender  _render;
      private readonly Controls _controls;

      public bool    Enabled  { get; private set; }
      public Vector2 MoveDir  { get; private set; }
      public Vector2 AimPos   { get; private set; }
      public bool    Shooting { get; private set; }
      public bool    Interact { get; private set; }



      public InputService(IRender render) {
         _render   = render;
         _controls = new Controls();
      }

      public void Dispose() => _controls.Dispose();



      public void Enable() {
         Enabled = true;
         _controls.Enable();
      }

      public void Disable() {
         Enabled = false;
         _controls.Disable();
      }



      public void Tick() {
         MoveDir  = Enabled ? _controls.Player.Move.ReadValue<Vector2>() : Vector2.zero;
         AimPos   = Enabled ? _render.Camera.ScreenToWorldPoint(_controls.Player.Aim.ReadValue<Vector2>()) : Vector2.zero;
         Shooting = Enabled && _controls.Player.Shoot.IsInProgress();
         Interact = Enabled && _controls.Player.Interact.WasPressedThisFrame();
      }
   }
}