using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factories.Hero {
   public class HeroFactory : Factory {
      private const string _CONTAINER_NAME = "Heroes";



      private readonly List<GameObject> _heroes;

      public IEnumerable<GameObject> Heroes => _heroes;



      public HeroFactory(IAssets assets) : base(assets) {
         _heroes = new List<GameObject>();
      }

      public async Task Spawn(Vector3 at) {
         GameObject heroIns = await
            Assets.Ins<GameObject>(
               "HERO",
               at,
               Quaternion.identity,
               Container(_CONTAINER_NAME)
            );

         _heroes.Add(heroIns);
      }
   }
}