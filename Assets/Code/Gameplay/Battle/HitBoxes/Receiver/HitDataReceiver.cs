using Data;
using EasyButtons;

namespace Battle.HitBoxes.Receiver {
   public abstract class HitDataReceiver<TSender, TReceiver> : Receiver<HitData, TSender, TReceiver>
      where TSender : Sender<HitData, TSender, TReceiver> //
      where TReceiver : HitDataReceiver<TSender, TReceiver> {
#if UNITY_EDITOR
      [Button]
      private void TakeAllFromChildren() {
         foreach (TSender sender in GetComponentsInChildren<TSender>())
            Add(sender);

         OnValidate();
      }
#endif
   }
}