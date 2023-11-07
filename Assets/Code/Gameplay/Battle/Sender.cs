using UnityEngine;

namespace Gameplay.Battle {
   public abstract class Sender<TData> : MonoBehaviour {
      public Receiver<TData> Receiver { get; private set; }

      public virtual void SetOwner(Receiver<TData> owner) => Receiver = owner;
      public virtual void Send(TData           data)  => Receiver.Receive(data);
   }
}