using System.Collections.Generic;
using UnityEngine;

namespace Envirenment.Locations {
   [CreateAssetMenu(menuName = "Level/new Locations Set")]
   public class LocationsSet : ScriptableObject {
      [SerializeField] private List<Location> locations;

      public IReadOnlyList<Location> Locations => locations;
   }
}