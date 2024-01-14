using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Data {
   public abstract class Receiver<T> : MonoBehaviour {
      public event Action<T> OnReceive;

      [SerializeField] private Entity          owner;
      [SerializeField] private List<Sender<T>> senders = new();

      public Entity                 Owner   => owner;
      public IEnumerable<Sender<T>> Senders => senders;



      private void Awake() {
         InitSenders();
      }

      protected void OnValidate() {
         senders = senders.ToHashSet().ToList();
      }



      public void Add(Sender<T> sender) {
         senders.Add(sender);
         sender.SetOwner(this);
      }

      public void Remove(Sender<T> sender) {
         senders.Remove(sender);
         sender.SetOwner(null);
      }


      public void Add(Receiver<T> receiver) {
         if (receiver == this) throw new Exception("Cant Add self!");

         receiver.OnReceive += Receive;
      }

      public void Remove(Receiver<T> receiver) {
         if (receiver == this) throw new Exception("Cant Remove self!");

         receiver.OnReceive -= Receive;
      }



      public virtual void Receive(T data) {
         OnReceive?.Invoke(data);
      }



      private void InitSenders() {
         foreach (Sender<T> sender in Senders) sender.SetOwner(this);
      }
   }
}