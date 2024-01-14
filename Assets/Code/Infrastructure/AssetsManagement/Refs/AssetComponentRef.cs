using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.AssetsManagement.Refs {
   [Serializable]
   public class AssetComponentRef<T> : AssetRef<GameObject> where T : Component {
      private    T _cashedAsset;
      public new T Asset => _cashedAsset ??= base.Asset.GetComponent<T>();



      public AssetComponentRef(string guid) : base(guid) { }



      public override bool ValidateAsset(Object obj) {
         return obj is GameObject go && go.TryGetComponent(out T _);
      }

      public override bool ValidateAsset(string mainAssetPath) {
#if UNITY_EDITOR
         return AssetDatabase.LoadAssetAtPath<T>(mainAssetPath);
#else
         return false;
#endif
      }

#if UNITY_EDITOR
      public  T EditorAsset => _cashedEditorAsset ??= !editorAsset.IsUnityNull() ? editorAsset.GetComponent<T>() : null;
      private T _cashedEditorAsset;
#endif
   }
}