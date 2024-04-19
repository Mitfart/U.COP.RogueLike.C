using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Infrastructure.AssetsManagement {
   public sealed class Assets : IAssets {
      public T Ins<T>(object key, Vector3 at = default, Quaternion? rot = null, Transform parent = null) {
         return InsAsync(key, at, rot, parent).WaitForCompletion().TryGetComponent(out T component)
            ? component
            : throw new NullReferenceException($"Can't find component {nameof(T)}");
      }

      public GameObject Ins(object key, Vector3 at = default, Quaternion? rot = null, Transform parent = null) {
         return InsAsync(key, at, rot, parent).WaitForCompletion();
      }



      public AsyncOperationHandle<GameObject> InsAsync(
         object      key,
         Vector3     at     = default,
         Quaternion? rot    = null,
         Transform   parent = null
      ) {
         return Addressables.InstantiateAsync(key, at, rot ?? Quaternion.identity, parent);
      }

      public async Task<T> InsAsync<T>(
         object      key,
         Vector3     at     = default,
         Quaternion? rot    = null,
         Transform   parent = null
      ) {
         GameObject ins = await Addressables.InstantiateAsync(key, at, rot ?? Quaternion.identity, parent).Task;

         return ins.TryGetComponent(out T component)
            ? component
            : throw new NullReferenceException($"Can't find component {nameof(T)}");
      }



      public AsyncOperationHandle<T> Load<T>(object key) where T : Object {
         return Addressables.LoadAssetAsync<T>(key);
      }

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