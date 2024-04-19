using UnityEngine;

namespace Battle.HitBoxes.Listeners {
   public class HitDataLogger : HitListener {
      protected override void Listen(HitData data) {
         Debug.Log(data);
      }
   }
}