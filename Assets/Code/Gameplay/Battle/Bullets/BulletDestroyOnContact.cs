using Battle.HitBoxes;
using Battle.HitBoxes.Listeners;

namespace Battle.Bullets {
   public class BulletDestroyOnContact : HitListener {
      public Bullet bullet;

      protected override void Listen(HitData data) {
         bullet.Destroy();
      }
   }
}