using UnityEngine;

namespace _Debug.Changers {
   public class FpsChanger : BaseChanger {
      [SerializeField, Range(min: 2, max: 500)] private int targetFps = 60;

      public override void Change()    => Application.targetFrameRate = targetFps;
      public override void Normalize() => Application.targetFrameRate = -1;
   }
}