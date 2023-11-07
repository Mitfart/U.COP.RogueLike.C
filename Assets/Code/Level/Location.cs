using System.Collections.Generic;
using Infrastructure.AssetsManagement.Refs;
using UnityEngine;

namespace Level {
   [CreateAssetMenu(menuName = "Level/new Location")]
   public class Location : ScriptableObject {
      [SerializeField] private string                        title;
      [SerializeField] private Color                         color;
      [SerializeField] private List<AssetComponentRef<Room>> rooms;

      public string                                 Title => title;
      public Color                                  Color => color;
      public IReadOnlyList<AssetComponentRef<Room>> Rooms => rooms;
   }
}