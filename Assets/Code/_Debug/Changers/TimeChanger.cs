using UnityEngine;

namespace _Debug.Changers {
   public class TimeChanger : BaseChanger {
      [SerializeField] private float newTimeScale = .1f;

      public override void Change()    => Time.timeScale = newTimeScale;
      public override void Normalize() => Time.timeScale = 1f;
   }
}