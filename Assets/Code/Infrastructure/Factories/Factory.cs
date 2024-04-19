using System.Collections.Generic;
using Infrastructure.AssetsManagement;
using UnityEngine;
using VContainer;

namespace Infrastructure.Factories {
   public abstract class Factory : IFactory {
#if UNITY_EDITOR
      private readonly Dictionary<string, Transform> _containers;
#endif
      protected readonly IAssets         assets;
      protected readonly IObjectResolver di;



      public Factory(IAssets assets, IObjectResolver di) {
         this.assets = assets;
         this.di     = di;

#if UNITY_EDITOR
         _containers = new Dictionary<string, Transform>();
#endif
      }

      public virtual void Reset() {
#if UNITY_EDITOR
         _containers.Clear();
#endif
      }



      protected Transform Container(string name, string key = null) {
#if UNITY_EDITOR
         key = ValidKey(key);

         if (!_containers.ContainsKey(key))
            _containers.Add(key, CreateContainer(name, key));

         return _containers[key];
#else
         return null;
#endif
      }

#if UNITY_EDITOR
      private static string ValidKey(string key) {
         return string.IsNullOrWhiteSpace(key) ? string.Empty : key;
      }

      private static Transform CreateContainer(string name, string key) {
         return string.IsNullOrWhiteSpace(key)
            ? new GameObject($"| {name} |").transform
            : new GameObject($"| {name} |__| {key} |").transform;
      }
#endif
   }
}