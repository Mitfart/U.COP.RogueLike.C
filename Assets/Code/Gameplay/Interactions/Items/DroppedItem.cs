using UnityEngine;

namespace Interactions.Items {
   public class DroppedItem : MonoBehaviour {
      public Interactable   interactable;
      public SpriteRenderer render;
      public Item           item;



      private void Start() => UpdateView();

      private void OnEnable()   => interactable.OnInteract += PickItem;
      private void OnDisable()  => interactable.OnInteract -= PickItem;
      private void OnValidate() => UpdateView();



      protected virtual void PickItem(HeroInteractor interactor) {
         interactor.hero.inventory.Pick(item);
         Destroy(gameObject);
      }

      private void UpdateView() => render.sprite = item.sprite;
   }
}