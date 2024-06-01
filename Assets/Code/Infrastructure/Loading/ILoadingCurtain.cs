using System.Threading.Tasks;
using UI;

namespace Infrastructure.Loading {
   public interface ILoadingCurtain {
      UIInfiniteBackground Background { get; }

      Task Begin();
      Task End();
   }
}