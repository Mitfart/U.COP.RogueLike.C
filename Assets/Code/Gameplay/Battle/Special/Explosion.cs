using System;
using System.Threading.Tasks;
using Battle.HitBoxes.Senders.Hurt;
using EasyButtons;
using Structs.Optional;
using Unity.VisualScripting;
using UnityEngine;

namespace Battle.Special {
   public class Explosion : MonoBehaviour {
      public event Action OnBegin;
      public event Action OnEnd;

      [SerializeField] private Optional<Transform> body;

      public          HurtCircle hurtCircle;
      [Min(0)] public float      duration;

      private ExplosionAnimation _animation;

      public Transform Body => body.enabled ? body.value : transform;



      private void Awake() {
         hurtCircle.enabled = false;

         TryGetComponent(out _animation);
      }

      [Button(Mode = ButtonMode.EnabledInPlayMode)]
      public async Task Explode() {
         hurtCircle.enabled = true;
         OnBegin?.Invoke();

         if (_animation.IsUnityNull())
            await Awaitable.WaitForSecondsAsync(duration);
         else
            await _animation.Play();

         OnEnd?.Invoke();
         hurtCircle.enabled = false;
      }
   }
}