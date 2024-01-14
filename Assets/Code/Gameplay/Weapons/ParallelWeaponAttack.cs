using System.Threading.Tasks;

namespace Gameplay.Weapons {
   public class ParallelWeaponAttack : CombinedWeaponAttack {
      public override Task Perform(Weapon weapon) {
         var attackTasks = new Task[attacks.Count];

         for (var i = 0; i < attacks.Count; i++)
            attackTasks[i] = attacks[i].Perform(weapon);

         return Task.WhenAll(attackTasks);
      }
   }
}