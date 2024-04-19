using Infrastructure.Factories.Hero;
using UnityEngine;
using VContainer;

namespace Envirenment.Interactions.Items {
   public class DroppedItem : MonoBehaviour {
      public Interactable   interactable;
      public SpriteRenderer render;
      public Item           item;

      private HeroFactory _heroFactory;



      [Inject]
      public void Construct(IObjectResolver di) {
         di.Inject(item);
      }

      private void Start() => UpdateView();

      private void OnEnable()  => interactable.OnInteract += PickItem;
      private void OnDisable() => interactable.OnInteract -= PickItem;



      private void PickItem() {
         item.PickItem();
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