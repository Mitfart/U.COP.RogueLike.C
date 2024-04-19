using DG.Tweening;
using UnityEngine;

namespace Envirenment.Interactions {
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



      private void ScaleUp()   => body.DOScale(scale.y, duration);
      private void ScaleDown() => body.DOScale(scale.x, duration);
   }
}