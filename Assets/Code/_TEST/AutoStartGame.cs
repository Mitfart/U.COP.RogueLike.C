using UI;
using UnityEngine;

namespace _TEST {
   public class AutoStartGame : MonoBehaviour {
      public UIMainMenu uiMainMenu;

      private void Start() => uiMainMenu.StartGame();
   }
}