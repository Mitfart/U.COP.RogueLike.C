namespace Infrastructure.Services.Time {
   public class TimeService : ITimeService {
      public float Delta             => UnityEngine.Time.deltaTime;
      public float FixedDelta        => UnityEngine.Time.fixedDeltaTime;
      public float Time              => UnityEngine.Time.time;
      public float RealTime          => UnityEngine.Time.realtimeSinceStartup;
      public float LevelTime         => UnityEngine.Time.timeSinceLevelLoad;
      public float ReverseDelta      => 1f / Delta;
      public float ReverseFixedDelta => 1f / FixedDelta;


      public float Elapsed(float from)                 => Time - from;
      public bool  Pass(float    from, float duration) => Elapsed(from) >= duration;
   }
}