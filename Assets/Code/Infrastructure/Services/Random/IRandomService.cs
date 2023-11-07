using UnityEngine;

namespace Infrastructure.Services.Random {
   public interface IRandomService {
      void    Init(int    seed);
      float   Range(float min, float max);
      float   Get();
      Vector2 InsideCircle(float radius = 1);
   }
}