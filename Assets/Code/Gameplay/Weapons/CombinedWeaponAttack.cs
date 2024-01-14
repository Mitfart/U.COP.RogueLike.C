using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Weapons {
   public abstract class CombinedWeaponAttack : WeaponAttack {
      [SerializeField] protected List<WeaponAttack> attacks;
   }
}