using Infrastructure.AssetsManagement;
using UnityEngine;
using VContainer;

namespace Extentions {
   public static class RegScriptableExt {
      public static void RegScriptable<TAsset>(this IContainerBuilder di, string path) where TAsset : ScriptableObject
         => di.Register(
                  r =>
                     r.Resolve<IAssets>()
                      .Load<TAsset>(path),
                  Lifetime.Singleton
               )
              .AsImplementedInterfaces()
              .AsSelf();

      public static void RegScriptable<TAsset>(this IContainerBuilder di, TAsset scriptable) where TAsset : ScriptableObject
         => di.Register(
                  _ => Object.Instantiate(scriptable),
                  Lifetime.Singleton
               )
              .AsImplementedInterfaces()
              .AsSelf();
   }
}