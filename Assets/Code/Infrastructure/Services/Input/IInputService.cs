using UnityEngine;

namespace Infrastructure.Services.Input {
   public interface IInputService {
      bool    Enabled  { get; }
      Vector2 MoveDir  { get; }
      Vector2 AimPos   { get; }
      bool    Shooting { get; }
      bool    Interact { get; }

      void Enable();
      void Disable();
   }
}