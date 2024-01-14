using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Infrastructure.AssetsManagement {
   public interface IAssets {
      T          Ins<T>(object key, Vector3 at = default, Quaternion? rot = null, Transform parent = null);
      GameObject Ins(object    key, Vector3 at = default, Quaternion? rot = null, Transform parent = null);

      AsyncOperationHandle<GameObject> InsAsync(object key, Vector3 at = default, Quaternion? rot = null, Transform parent = null);

      AsyncOperationHandle<T> Load<T>(object key) where T : Object;
      void                    Unload(object  key);
   }
}