using Data;

namespace Battle.HitBoxes.Senders {
   public abstract class HitDataSender<TSender, TReceiver> : Sender<HitData, TSender, TReceiver>
      where TSender : Sender<HitData, TSender, TReceiver> //
      where TReceiver : Receiver<HitData, TSender, TReceiver> { }
}