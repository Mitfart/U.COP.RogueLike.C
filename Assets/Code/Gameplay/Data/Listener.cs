using Unity.VisualScripting;
using UnityEngine;

namespace Data {
   public abstract class Listener<TData> : MonoBehaviour {
      [SerializeField] private Receiver<TData> receiver;

      public Entity Owner => receiver.Owner;



      private void OnEnable()  => receiver.OnReceive += Listen;
      private void OnDisable() => receiver.OnReceive -= Listen;

      public virtual void SetOwner(Receiver<TData> owner) {
         if (!receiver.IsUnityNull())
            receiver.OnReceive -= Listen;

         receiver = owner;

         receiver.OnReceive += Listen;
      }

      protected abstract void Listen(TData data);
   }
}