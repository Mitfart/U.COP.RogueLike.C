using System.Collections.Generic;
using UnityEngine;

namespace Level {
   [CreateAssetMenu(menuName = "Level/new Locations Set")]
   public class LocationsSet : ScriptableObject {
      [SerializeField] private List<Location[]> _locations;

      public IReadOnlyList<Location[]> Locations => _locations;
   }
}