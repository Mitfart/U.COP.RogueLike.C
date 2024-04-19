using Attributes.ReadOnly;
using DefaultNamespace;
using DG.Tweening;
using Infrastructure.Factories.Items;
using Interactions.Items;
using UnityEngine;
using VContainer;

namespace Interactions.Loot {
   public class Treasure : MonoBehaviour {
      public              LootBag      lootBag;
      public              Interactable interactable;
      [SpaceAfter] public Animator     animator;

      [Header("Spawn Items")] [Min(1)]              public int     count       = 1;
      [Min(                        Consts.EPSILON)] public float   gap         = .25f;
      public                                               Vector2 spreadRange = new(0f, 1f);
      [Min(Consts.EPSILON)] public                         float   duration    = .5f;

      private bool         _isOpen;
      private ItemsFactory _itemsFactory;

      private static readonly int IsOpen = Animator.StringToHash("IsOpen");



      [Inject]
      public void Construct(ItemsFactory itemsFactory) {
         _itemsFactory = itemsFactory;
      }

      private void OnEnable()  => interactable.OnInteract += OpenLoot;
      private void OnDisable() => interactable.OnInteract -= OpenLoot;



      private void OpenLoot(HeroInteractor _) {
         if (_isOpen)
            return;

         interactable.Off();

         _isOpen = true;
         animator.SetBool(IsOpen, _isOpen);

         DropItems();
      }


      private async void DropItems() {
         for (var i = 0; i < count; i++) {
            DroppedItem droppedItem = DropRandomItem();
            JumpItem(droppedItem);

            await Awaitable.WaitForSecondsAsync(gap);
         }
      }

      private DroppedItem DropRandomItem() {
         return _itemsFactory.DropItem(lootBag.GetRandom(), transform.position);
      }

      private void JumpItem(Component droppedItem) {
         float jumpPower = Random.Range(spreadRange.x, spreadRange.y);

         droppedItem.transform.DOJump(
            transform.Position2D() + Random.insideUnitCircle * jumpPower, //
            jumpPower * .5f,
            1,
            duration
         );
      }
   }
}