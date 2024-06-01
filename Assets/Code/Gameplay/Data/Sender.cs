using UnityEngine;

namespace Data {
   public abstract class Sender<TData, TSender, TReceiver> : MonoBehaviour
      where TSender : Sender<TData, TSender, TReceiver> //
      where TReceiver : Receiver<TData, TSender, TReceiver> {
      public TReceiver Receiver { get; private set; }

      public Entity Owner => Receiver.Owner;

      
      public void SetOwner(TReceiver owner) => Receiver = owner;

      public void Send(TData data) => Receiver.Receive(data);
   }
}