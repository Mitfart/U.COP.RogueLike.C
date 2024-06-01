using UnityEngine;
using UnityEngine.UI;

namespace UI {
   public class UIInfiniteBackground : MonoBehaviour {
      public RawImage bg;
      public Vector2  speed;

      private Vector2 _startPosition;
      private float   _evaluatedTime;



      private void Awake() {
         _startPosition = bg.uvRect.position;
      }

      private void Update() {
         _evaluatedTime += Time.deltaTime;

         bg.uvRect = new Rect(
            _startPosition + bg.uvRect.size * speed * _evaluatedTime,
            bg.uvRect.size
         );
      }



      public void Sync(UIInfiniteBackground other) {
         _evaluatedTime = other._evaluatedTime;
      }
   }
}