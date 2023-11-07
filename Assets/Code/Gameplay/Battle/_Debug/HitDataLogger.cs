using Gameplay.Battle.Listeners;

namespace Gameplay.Battle.Debug {
   public class HitDataLogger : Listener<HitData> {
      protected override void Receive(HitData data) => UnityEngine.Debug.Log(data);
   }
}