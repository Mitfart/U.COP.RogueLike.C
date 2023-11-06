using VContainer;

namespace Extentions {
   public static class ResolveOnBuildExt {
      public static void ResolveOnBuild<T>(this IContainerBuilder di)
         => di.RegisterBuildCallback(
            resolver => resolver.Resolve<T>()
         );
   }
}