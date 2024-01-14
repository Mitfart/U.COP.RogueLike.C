using System;
using UnityEngine;

namespace Gameplay.Unit {
   public class FaceIntoViewDirection : MonoBehaviour {
      public enum Method {
         RotationY = 0,
         Scale     = 1
      }

      public View      view;
      public Transform body;
      public Method    method;



      private void OnEnable()  => view.OnChangeDirection += FaceInto;
      private void OnDisable() => view.OnChangeDirection -= FaceInto;



      private void FaceInto(Vector2 dir) {
         switch (method) {
            case Method.Scale:
               FaceIntoScale(dir);
               break;
            case Method.RotationY:
               FaceIntoRot(dir);
               break;
            default:
               throw new ArgumentOutOfRangeException();
         }
      }

      private void FaceIntoScale(Vector2 dir) {
         Vector3 scale = body.localScale;
         scale.x         = Mathf.Sign(dir.x);
         body.localScale = scale;
      }

      private void FaceIntoRot(Vector2 dir) {
         Vector3 angles = body.eulerAngles;
         angles.y         = (Mathf.Sign(dir.x) - 1) * 90;
         body.eulerAngles = angles;
      }
   }
}