using UnityEngine;

namespace Infrastructure.Services.Random {
   public class RandomService : IRandomService {
      public void    Init(int    seed)           => UnityEngine.Random.InitState(seed);
      public float   Range(float min, float max) => UnityEngine.Random.Range(min, max);
      public float   Get()                          => UnityEngine.Random.value;
      public Vector2 InsideCircle(float radius = 1) => UnityEngine.Random.insideUnitCircle * radius;
   }
}