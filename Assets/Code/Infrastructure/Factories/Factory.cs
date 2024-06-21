using System.Collections.Generic;
using Extensions;
using Infrastructure.AssetsManagement;
using Locations;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Factories {
   public abstract class Factory : IFactory {
#if UNITY_EDITOR
      private readonly Dictionary<string, Transform> _containers;
#endif
      protected readonly IAssets         Assets;
      protected readonly IObjectResolver Di;



      public Factory(IAssets assets, IObjectResolver di) {
         this.Assets = assets;
         this.Di     = di;

#if UNITY_EDITOR
         _containers = new Dictionary<string, Transform>();
#endif
      }

      public virtual void Reset() {
#if UNITY_EDITOR
         _containers.CleanUp();
#endif
      }



      protected T GetOrSpawn<T>(
         T           obj,
         object      key,
         Transform   container = null,
         Vector3     at        = default,
         Quaternion? rot       = null
      ) where T : Component {
         return obj.IsUnityNull() ? Spawn<T>(key, container, at, rot) : obj;
      }

      protected T Spawn<T>(
         object      key,
         Transform   container = null,
         Vector3     at        = default,
         Quaternion? rot       = null
      ) where T : Component {
         T ins = Assets.Ins<T>(
            key,
            at,
            rot,
            container
         );
         Di.InjectGameObject(ins.gameObject);
         return ins;
      }

      protected T Spawn<T>(
         SpawnPoint<T> spawnPoint,
         string        tag = null,
         Quaternion?   rot = null
      ) where T : Component {
         T ins = Assets.Ins<T>(
            spawnPoint.Key,
            spawnPoint.Position,
            rot,
            Container(tag, spawnPoint.DebugName)
         );
         Di.InjectGameObject(ins.gameObject);
         return ins;
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
      private static string ValidKey(string key) => string.IsNullOrWhiteSpace(key) ? string.Empty : key;

      private static Transform CreateContainer(string name, string key)
         => string.IsNullOrWhiteSpace(key)
            ? new GameObject($"| {name} |").transform
            : new GameObject($"| {name} |__| {key} |").transform;
#endif
   }
}