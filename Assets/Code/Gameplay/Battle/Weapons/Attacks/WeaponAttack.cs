using System.Threading.Tasks;
using UnityEngine;

namespace Battle.Weapons.Attacks {
   public abstract class WeaponAttack : MonoBehaviour {
      public abstract Task Perform(Weapon weapon);
   }
}