using UnityEngine;

namespace DefaultNamespace {
   public static class OnOffExt {
      public static TBeh On<TBeh>(this TBeh behaviour) where TBeh : Behaviour {
         behaviour.enabled = true;
         return behaviour;
      }

      public static TBeh Off<TBeh>(this TBeh behaviour) where TBeh : Behaviour {
         behaviour.enabled = false;
         return behaviour;
      }
   }
}