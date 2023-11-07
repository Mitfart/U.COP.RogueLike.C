using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Infrastructure.AssetsManagement {
   public sealed class Assets : IAssets {
      public async Task<T> Ins<T>(object key, Vector3 at = default, Quaternion? rot = null, Transform parent = null) {
         GameObject obj = await Ins(key, at, rot, parent);

         if (!obj.TryGetComponent(out T component)) throw new NullReferenceException($"Can't Instantiate: [ type: {typeof(T)}, key: {key} ]");

         return component;
      }

      public async Task<GameObject> Ins(object key, Vector3 at = default, Quaternion? rot = null, Transform parent = null)
         => await Addressables
                 .InstantiateAsync(
                     key,
                     at,
                     rot ?? Quaternion.identity,
                     parent
                  )
                 .Task;

      public async Task<T> Load<T>(object key) where T : Object
         => await Addressables
                 .LoadAssetAsync<T>(key)
                 .Task;

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