using System.Threading.Tasks;

namespace Infrastructure.Loading {
   public interface ILoadingCurtain {
      Task Begin();
      Task Progress(float progress);
      Task End();
   }
}