using System.Threading.Tasks;
using Battle.Bullets.Spawners;
using Infrastructure.Services.Random;
using UnityEngine;
using VContainer;

namespace Battle.Weapons.Attacks {
   public class RangeWeaponAttack : WeaponAttack {
      private const float _MIN_SPREAD = 0F;
      private const float _MAX_SPREAD = 360F;

      public BulletsSpawner spawner;

      [SerializeField] private float additionalSpreadAngle;

      private IRandomService _random;

      public float AdditionalSpreadAngle {
         get => additionalSpreadAngle;
         set => additionalSpreadAngle = Mathf.Clamp(value, _MIN_SPREAD, _MAX_SPREAD);
      }



      [Inject] public void Construct(IRandomService random) => _random = random;



      public override async Task Perform(Weapon weapon) => await spawner.Spawn(bullet => bullet.Init(weapon).Rotate2D(CalcAdditionalSpreadAngle()));

      
      
      private float CalcAdditionalSpreadAngle() => _random.Range(min: -.5f, max: .5f) * AdditionalSpreadAngle;
   }
}