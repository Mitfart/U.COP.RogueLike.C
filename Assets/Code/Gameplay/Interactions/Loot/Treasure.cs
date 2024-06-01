using System;
using System.Threading.Tasks;
using Attributes.ReadOnly;
using DefaultNamespace;
using DG.Tweening;
using EasyButtons;
using Infrastructure.Factories.Items;
using Interactions.Items;
using Structs.Ranged;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Interactions.Loot {
   public class Treasure : MonoBehaviour {
      private static readonly int _IsOpen = Animator.StringToHash(name: "IsOpen");

      [SerializeField, RangeEdges(min: 0, max: 99)] private Ranged heartsCount = new(min: 0, max: 0, rounded: true);

      public              LootBag      lootBag;
      public              Interactable interactable;
      [SpaceAfter] public Animator     animator;

      public DropParams dropItems = new(1, .25f, new Vector2(x: 0f, y: 1f), .5f);

      private bool         _isOpen;
      private ItemsFactory _itemsFactory;



      [Inject] public void Construct(ItemsFactory itemsFactory) => _itemsFactory = itemsFactory;

      private void OnEnable()  => interactable.OnInteract += OpenLoot;
      private void OnDisable() => interactable.OnInteract -= OpenLoot;



      private void OpenLoot(HeroInteractor _) {
         if (_isOpen)
            return;

         interactable.Off();

         _isOpen = true;
         animator.SetBool(_IsOpen, _isOpen);

         DropItems();
         DropHearts();
      }


      [Button(Mode = ButtonMode.EnabledInPlayMode)] private async void DropItems()  => await Drop(RandomItem, dropItems.count);
      [Button(Mode = ButtonMode.EnabledInPlayMode)] private async void DropHearts() => await Drop(Heart,      heartsCount.RandomInt());


      private async Task Drop(Func<Component> spawnFunc, int amount) {
         for (var i = 0; i < amount; i++) {
            Component droppedItem = spawnFunc();
            JumpItem(droppedItem);

            await Awaitable.WaitForSecondsAsync(dropItems.gap);
         }
      }

      private DroppedItem  RandomItem() => _itemsFactory.DropItem(lootBag.GetRandom(), transform.position);
      private DroppedHeart Heart()      => _itemsFactory.DropHeart(transform.position);



      private void JumpItem(Component droppedItem) {
         float jumpPower = Random.Range(dropItems.spreadRange.x, dropItems.spreadRange.y);

         droppedItem.transform.DOJump(
            transform.Position2D() + Random.insideUnitCircle * jumpPower, //
            jumpPower * .5f,
            numJumps: 1,
            dropItems.duration
         );
      }

      [Serializable]
      public struct DropParams {
         [Min(min: 1)]         public int     count;
         [Min(Consts.EPSILON)] public float   gap;
         public                       Vector2 spreadRange;
         [Min(Consts.EPSILON)] public float   duration;

         public DropParams(int count, float gap, Vector2 spreadRange, float duration) {
            this.count       = count;
            this.gap         = gap;
            this.spreadRange = spreadRange;
            this.duration    = duration;
         }
      }
   }
}