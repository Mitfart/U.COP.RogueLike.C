using UnityEngine;
using UnityEngine.EventSystems;

namespace UI {
   public class UIRoot : MonoBehaviour {
      [field: SerializeField] public Canvas      Canvas      { get; private set; }
      [field: SerializeField] public EventSystem EventSystem { get; private set; }
   }
}