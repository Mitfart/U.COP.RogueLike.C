using System.Threading.Tasks;

namespace Extensions {
   public static class ToTaskExt {
      public static async Task<TOperation> ToTask<TOperation>(this TOperation asyncOperation)
         where TOperation : UnityEngine.AsyncOperation {
         while (!asyncOperation.isDone)
            await Task.Yield();

         return asyncOperation;
      }
   }
}