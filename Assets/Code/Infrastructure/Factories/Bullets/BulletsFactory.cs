using System.Collections.Generic;
using Battle.Bullets;
using Extensions;
using Infrastructure.AssetsManagement;
using Infrastructure.AssetsManagement.Refs;
using UnityEngine;
using VContainer;

namespace Infrastructure.Factories.Bullets {
   public class BulletsFactory : Factory {
      private const string _TAG = "Bullets";

      public List<Bullet> Bullets { get; } = new();



      public BulletsFactory(IAssets assets, IObjectResolver di) : base(assets, di) { }

      public override void Reset() {
         base.Reset();
         Bullets.CleanUp();
      }



      public Bullet Spawn(AssetComponentRef<Bullet> asset, Vector3 at, Quaternion rot) {
         Bullet ins = Spawn<Bullet>(asset, Container(_TAG), at, rot);

         Bullets.Add(ins);
         ins.OnDestroy += RemoveAfterDestroy;

         return ins;

         void RemoveAfterDestroy() {
            Bullets.Remove(ins);
            ins.OnDestroy -= RemoveAfterDestroy;
         }
      }
   }
}