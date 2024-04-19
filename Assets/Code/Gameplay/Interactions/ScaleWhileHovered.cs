using DG.Tweening;
using UnityEngine;

namespace Interactions {
   public class ScaleWhileHovered : MonoBehaviour {
      public Interactable interactable;
      public Transform    body;
      public Vector2      scale;
      public float        duration = .125f;



      private void OnEnable() {
         interactable.OnHover   += ScaleUp;
         interactable.OnUnhover += ScaleDown;
      }

      private void OnDisable() {
         interactable.OnHover   -= ScaleUp;
         interactable.OnUnhover -= ScaleDown;
      }



      private void ScaleUp(HeroInteractor   _) => body.DOScale(scale.y, duration);
      private void ScaleDown(HeroInteractor _) => body.DOScale(scale.x, duration);
   }
}