using Attributes.ReadOnly;
using UnityEngine;

namespace Interactions.Items {
   public abstract class Item : ScriptableObject {
      public              Sprite sprite;
      public              string title;
      [SpaceAfter] public string description;



      public abstract void Apply(Entity  entity);
      public abstract void Revoke(Entity entity);
   }
}