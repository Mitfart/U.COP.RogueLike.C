using Data;
using UnityEngine;

namespace Battle.HitBoxes.Listeners {
   [RequireComponent(typeof(Receiver<HitData>))]
   public abstract class HitListener : Listener<HitData> { }
}