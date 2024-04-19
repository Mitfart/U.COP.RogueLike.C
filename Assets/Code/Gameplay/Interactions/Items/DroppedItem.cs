using Infrastructure.Factories.Hero;
using UnityEngine;
using VContainer;

namespace Interactions.Items {
   public class DroppedItem : MonoBehaviour {
      public Interactable   interactable;
      public SpriteRenderer render;
      public Item           item;



      private void Start() => UpdateView();

      private void OnEnable()  => interactable.OnInteract += PickItem;
      private void OnDisable() => interactable.OnInteract -= PickItem;



      private void PickItem(HeroInteractor interactor) {
         item.PickItem(interactor.hero.inventory);
         Destroy(gameObject);
      }

      private void UpdateView() {
         render.sprite = item.sprite;
      }



      private void OnValidate() {
         UpdateView();
      }
   }
}