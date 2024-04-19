using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Data {
   public abstract class Receiver<TData, TSender, TReceiver> : Receiver<TData>
      where TSender : Sender<TData, TSender, TReceiver> //
      where TReceiver : Receiver<TData, TSender, TReceiver> {
      [SerializeField] private List<TReceiver> subReceivers = new();
      [SerializeField] private List<TSender>   senders      = new();

      public TReceiver Parent { get; private set; }

      public IEnumerable<TReceiver> SubReceivers => subReceivers;
      public IEnumerable<TSender>   Senders      => senders;

      public override Entity Owner => Parent.IsUnityNull() ? owner : Parent.Owner;



      private void Awake() {
         InitSubReceivers();
         InitSenders();
      }

      protected void OnValidate() {
         senders = Enumerable.ToHashSet(senders).ToList();
      }



      public void Add(TSender sender) {
         senders.Add(sender);
         sender.SetOwner((TReceiver)this);
      }

      public void Remove(TSender sender) {
         senders.Remove(sender);
         sender.SetOwner(null);
      }


      public void Add(TReceiver subReceiver) {
         if (subReceiver == this)
            throw new Exception("Cant Add self!");

         subReceivers.Add(subReceiver);
         subReceiver.OnReceive += Receive;
         subReceiver.Parent    =  (TReceiver)this;
      }

      public void Remove(TReceiver subReceiver) {
         if (subReceiver == this)
            throw new Exception("Cant Remove self!");

         subReceivers.Remove(subReceiver);
         subReceiver.OnReceive -= Receive;
         subReceiver.Parent    =  null;
      }



      private void InitSenders() {
         foreach (TSender sender in Senders)
            sender.SetOwner((TReceiver)this);
      }

      private void InitSubReceivers() {
         foreach (TReceiver subReceiver in subReceivers) {
            subReceiver.owner     =  owner;
            subReceiver.OnReceive += Receive;
         }
      }
   }


   public abstract class Receiver<TData> : MonoBehaviour {
      public event Action<TData> OnReceive;

      [SerializeField] protected Entity owner;

      public virtual Entity Owner => owner;



      public virtual void Receive(TData data) {
         OnReceive?.Invoke(data);
      }
   }
}