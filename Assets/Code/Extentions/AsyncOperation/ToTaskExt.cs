using System.Threading.Tasks;
using UnityEngine;

namespace Extentions {
   public static class ToTaskExt {
      public static async Task<TOperation> ToTask<TOperation>(this TOperation asyncOperation) where TOperation : AsyncOperation {
         while (!asyncOperation.isDone)
            await Task.Yield();

         return asyncOperation;
      }
   }
}