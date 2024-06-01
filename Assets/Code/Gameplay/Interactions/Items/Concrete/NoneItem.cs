using System;
using UnityEngine;

namespace Interactions.Items.Concrete {
   [CreateAssetMenu(menuName = "item/new NoneItem")]
   public class NoneItem : Item {
      public override void Apply(Entity  entity) => throw new NotImplementedException();
      public override void Revoke(Entity entity) => throw new NotImplementedException();
   }
}