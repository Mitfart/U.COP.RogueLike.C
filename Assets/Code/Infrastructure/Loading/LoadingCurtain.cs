using System.Threading.Tasks;
using Attributes.ReadOnly;
using DefaultNamespace;
using DG.Tweening;
using EasyButtons;
using UI;
using UnityEngine;

namespace Infrastructure.Loading {
   public class LoadingCurtain : MonoBehaviour, ILoadingCurtain {
      public              CanvasGroup canvasGroup;
      public              float       duration;
      [SpaceAfter] public Ease        ease;

      [field: SerializeField] public UIInfiniteBackground Background { get; private set; }



      [Button(Mode = ButtonMode.EnabledInPlayMode)]
      public async Task Begin() {
         this.On();
         await Fade(fade: 1);
      }

      [Button(Mode = ButtonMode.EnabledInPlayMode)]
      public async Task End() {
         await Fade(fade: 0);
         this.Off();
      }


      private Task Fade(float fade) => canvasGroup.DOFade(fade, duration).SetEase(ease).AsyncWaitForCompletion();
   }
}