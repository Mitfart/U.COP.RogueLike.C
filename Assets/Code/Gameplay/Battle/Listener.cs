using UnityEngine;

namespace Gameplay.Battle.Listeners {
   public abstract class Listener<TData> : MonoBehaviour {
      private Receiver<TData> _receiver;

      private void Awake()     => _receiver = GetComponent<Receiver<TData>>();
      private void OnEnable()  => _receiver.OnReceive += Receive;
      private void OnDisable() => _receiver.OnReceive -= Receive;

      protected abstract void Receive(TData data);
   }
}