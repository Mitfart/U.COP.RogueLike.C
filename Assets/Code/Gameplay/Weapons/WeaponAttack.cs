using System.Threading.Tasks;
using UnityEngine;

namespace Gameplay.Weapons {
   public abstract class WeaponAttack : MonoBehaviour {
      public abstract Task Perform(Weapon weapon);
   }
}