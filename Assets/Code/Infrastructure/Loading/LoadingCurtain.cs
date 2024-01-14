using System.Threading.Tasks;
using DG.Tweening;
using EasyButtons;
using UnityEngine;

namespace Infrastructure.Loading {
   public class LoadingCurtain : MonoBehaviour, ILoadingCurtain {
      public RectTransform root;
      public CanvasGroup   canvasGroup;
      public float         duration;
      public Ease          ease;



      private void Start() {
         ZeroPivotX();
      }


      [Button]
      public Task Begin() {
         return Fade(1);
      }

      [Button]
      public Task End() {
         return Fade(0);
      }

      [Button]
      public Task Progress(float progress) {
         return null;
      }


      private Task Fade(float fade) {
         return canvasGroup.DOFade(fade, duration).SetEase(ease).AsyncWaitForCompletion();
      }

      private void ZeroPivotX() {
         root.pivot = new Vector2(0f, root.pivot.y);
      }
   }
}