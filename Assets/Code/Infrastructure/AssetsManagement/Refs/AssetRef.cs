using System;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Infrastructure.AssetsManagement.Refs {
   [Serializable]
   public class AssetRef<T> : AssetReferenceT<T> where T : Object {
      public new T Asset => base.Asset as T;

      public AssetRef(string guid) : base(guid) { }
   }
}