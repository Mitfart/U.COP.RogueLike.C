using EasyButtons;

namespace Gameplay.Battle {
   public abstract class HitDataReceiver<T> : Receiver<HitData>
      where T : Sender<HitData> {
#if UNITY_EDITOR
      [Button]
      private void TakeAllFromChildren() {
         foreach (T sender in GetComponentsInChildren<T>()) Add(sender);

         OnValidate();
      }
#endif
   }
}