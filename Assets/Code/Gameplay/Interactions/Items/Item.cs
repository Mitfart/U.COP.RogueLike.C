using Attributes.ReadOnly;
using Infrastructure.Factories.Hero;
using UnityEngine;

namespace Interactions.Items {
   public abstract class Item : ScriptableObject {
      public              Sprite sprite;
      public              string title;
      [SpaceAfter] public string description;

      protected HeroFactory HeroFactory { get; private set; }



      public abstract void Apply(Entity  entity);
      public abstract void Revoke(Entity entity);

      public void PickItem(Inventory inventory) => inventory.Pick(this);
   }
}