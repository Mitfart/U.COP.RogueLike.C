using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Gameplay {
   public abstract class Spawner<TComp> : MonoBehaviour where TComp : Component {
      public abstract Task Spawn(Action<TComp> onSpawnBullet);
   }
}