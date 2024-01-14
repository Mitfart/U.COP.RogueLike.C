using Gameplay.Data;
using UnityEngine;

namespace Gameplay.Battle.Listeners {
   public class HitDataLogger : Listener<HitData> {
      protected override void Receive(HitData data) => Debug.Log(data);
   }
}