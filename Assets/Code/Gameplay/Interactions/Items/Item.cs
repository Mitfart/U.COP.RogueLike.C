using Attributes.ReadOnly;
using Infrastructure.Factories.Hero;
using UnityEngine;
using VContainer;

namespace Envirenment.Interactions.Items {
   public abstract class Item : ScriptableObject {
      public              Sprite sprite;
      public              string title;
      [SpaceAfter] public string description;

      protected HeroFactory HeroFactory { get; private set; }



      protected void Construct(HeroFactory heroFactory) {
         HeroFactory = heroFactory;
      }

      public abstract void Apply(Entity  entity);
      public abstract void Revoke(Entity entity);

      public virtual void PickItem() {
         HeroFactory.Hero.inventory.Pick(this);
      }
   }
}