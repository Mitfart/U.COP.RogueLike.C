using System.Threading.Tasks;
using DG.Tweening;
using EasyButtons;
using Structs.Ranged;
using UnityEngine;

namespace Battle.Special {
   [RequireComponent(typeof(Explosion))]
   public class ExplosionAnimation : MonoBehaviour {
      public          Ranged animationParts = new(.1f, .25f);
      [Min(0)] public float  scale          = 2f;

      public Ease beginEase = Ease.InSine;
      public Ease endEase   = Ease.OutSine;

      private Explosion _explosion;

      private Vector3 Durations
         => _explosion.duration
          * new Vector3( //
               animationParts.Min,
               animationParts.Max     - animationParts.Min,
               animationParts.MaxEdge - animationParts.Max
            );



      private void Awake() {
         _explosion = GetComponent<Explosion>();
         EndAnimationAbsolute();
      }

      [Button(Mode = ButtonMode.EnabledInPlayMode)]
      public async Task Play() {
         EndAnimationAbsolute();

         await _explosion //
              .Body
              .DOScale(Vector3.one * scale, Durations.x)
              .SetEase(beginEase)
              .AsyncWaitForCompletion();

         await Awaitable.WaitForSecondsAsync(Durations.y);

         await _explosion //
              .Body
              .DOScale(Vector3.zero, Durations.z)
              .SetEase(endEase)
              .AsyncWaitForCompletion();

         EndAnimationAbsolute();
      }

      private void EndAnimationAbsolute() {
         _explosion.Body.localScale = Vector3.zero;
      }
   }
}