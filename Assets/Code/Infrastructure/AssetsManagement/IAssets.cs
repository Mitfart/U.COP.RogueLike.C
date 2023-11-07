using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.AssetsManagement {
   public interface IAssets {
      Task<T>          Ins<T>(object key, Vector3 at = default, Quaternion? rot = null, Transform parent = null);
      Task<GameObject> Ins(object    key, Vector3 at = default, Quaternion? rot = null, Transform parent = null);

      Task<T> Load<T>(object key) where T : Object;
      void    Unload(object  key);
   }
}