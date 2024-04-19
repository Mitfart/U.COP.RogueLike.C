using Infrastructure.AssetsManagement;
using UI.Menus;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Factories.UIFactory {
   public class UIFactory : Factory {
      private const string _CONTAINER_NAME = "UI";



      public UIFactory(IAssets assets, IObjectResolver di) : base(assets, di) { }

      public MainMenu InsMainMenu() {
         var ins = assets.Ins<MainMenu>( //
            "MAIN_MENU",
            Vector3.zero,
            Quaternion.identity,
            Container(_CONTAINER_NAME, "MAIN_MENU")
         );
         di.InjectGameObject(ins.gameObject);
         return ins;
      }
   }
}