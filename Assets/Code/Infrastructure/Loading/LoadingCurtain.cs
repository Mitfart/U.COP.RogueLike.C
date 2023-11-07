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



      private void Start() => ZeroPivotX();


      [Button] public Task Begin() => Fade(fade: 1);
      [Button] public Task End()   => Fade(fade: 0);

      [Button] public Task Progress(float progress) => null;

      
      private Task Fade(float fade)
         => canvasGroup
           .DOFade(fade, duration)
           .SetEase(ease)
           .AsyncWaitForCompletion();

      private void ZeroPivotX() => root.pivot = new Vector2(x: 0f, root.pivot.y);
   }
}