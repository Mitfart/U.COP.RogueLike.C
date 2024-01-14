using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Infrastructure.AssetsManagement {
   public sealed class Assets : IAssets {
      public T Ins<T>(
         object      key,
         Vector3     at     = default,
         Quaternion? rot    = null,
         Transform   parent = null
      )
         => Ins(key, at, rot, parent)
           .TryGetComponent(out T component)
            ? component
            : throw new NullReferenceException($"Can't find component {nameof(T)}");

      public GameObject Ins(
         object      key,
         Vector3     at     = default,
         Quaternion? rot    = null,
         Transform   parent = null
      )
         => Addressables.InstantiateAsync(key, at, rot ?? Quaternion.identity, parent).WaitForCompletion();



      public AsyncOperationHandle<GameObject> InsAsync(
         object      key,
         Vector3     at     = default,
         Quaternion? rot    = null,
         Transform   parent = null
      )
         => Addressables.InstantiateAsync(key, at, rot ?? Quaternion.identity, parent);



      public AsyncOperationHandle<T> Load<T>(object key) where T : Object => Addressables.LoadAssetAsync<T>(key);

      public void Unload(object key) {
         // @formatter:off
         switch (key) {
            case GameObject obj: Addressables.ReleaseInstance(obj); break;
            case Component comp: Addressables.ReleaseInstance(comp.gameObject); break;
            case AssetReference asset: asset.ReleaseAsset(); break;
            default:             Addressables.Release(key); break;
         }
         // @formatter:on
      }
   }
}