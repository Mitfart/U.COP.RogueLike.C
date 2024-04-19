using System;
using Units.Behavior.Tree;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Units.Behavior.Nodes {
   public class Instantiate<TObj> : Node where TObj : Component {
      private readonly TObj         _prefab;
      private readonly Action<TObj> _onSpawn;



      public Instantiate(TObj prefab, Action<TObj> onSpawn) {
         _prefab  = prefab;
         _onSpawn = onSpawn;
      }

      protected override void OnBegin() {
         TObj ins = Object.Instantiate(_prefab, Entity.Position, Entity.Rotation);

         _onSpawn?.Invoke(ins);
      }
   }
}