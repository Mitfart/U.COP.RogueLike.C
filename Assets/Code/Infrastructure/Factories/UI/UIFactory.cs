using Infrastructure.AssetsManagement;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace Infrastructure.Factories.UI {
   public class UIFactory : Factory {
      private const string _ROOT       = "UI_ROOT";
      private const string _MAIN_MENU  = "UI_MAIN_MENU";
      private const string _END_SCREEN = "UI_END_SCREEN";
      private const string _HUD_UI     = "UI_HUD";

      private UIRoot      _uiRoot;
      private UIMainMenu  _uiMainMenu;
      private UIEndScreen _uiEndScreen;
      private UIHero      _uiHero;



      public UIFactory(IAssets assets, IObjectResolver di) : base(assets, di) { }

      public override void Reset() {
         base.Reset();

         if (!_uiRoot.IsUnityNull())
            Object.Destroy(_uiRoot.gameObject);
         if (!_uiMainMenu.IsUnityNull())
            Object.Destroy(_uiMainMenu.gameObject);
         if (!_uiEndScreen.IsUnityNull())
            Object.Destroy(_uiEndScreen.gameObject);
         if (!_uiHero.IsUnityNull())
            Object.Destroy(_uiHero.gameObject);

         _uiRoot      = null;
         _uiMainMenu  = null;
         _uiEndScreen = null;
         _uiHero      = null;
      }



      public UIMainMenu  InsMainMenu()                => _uiMainMenu = GetOrSpawn(_uiMainMenu,   _MAIN_MENU,  UICanvas(), UICanvas().position).SetRoot(_uiRoot);
      public UIEndScreen InsEndGameScreen(bool  win)  => _uiEndScreen = GetOrSpawn(_uiEndScreen, _END_SCREEN, UICanvas(), UICanvas().position).WinView(win).SetRoot(_uiRoot);
      public UIHero      InsHUD(Units.Hero.Hero hero) => _uiHero = GetOrSpawn(_uiHero,           _HUD_UI,     UICanvas(), UICanvas().position).With(ui => ui.Hero = hero);

      private Transform UICanvas() => (_uiRoot = GetOrSpawn(_uiRoot, _ROOT)).transform;
   }
}