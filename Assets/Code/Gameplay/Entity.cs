using UnityEngine;

namespace Gameplay {
   public class Entity : MonoBehaviour {
      // private readonly Dictionary<Type, object> _cachedComponents = new();

      [field: SerializeField] public string Name { get; private set; }
      [field: SerializeField] public Team   Team { get; private set; }



      // public T Get<T>() where T : Component
      //    => TryGetCached<T>(out object cachedComponent)
      //       ? (T)cachedComponent
      //       : GetAndCache<T>();
      //
      // public bool Has<T>() where T : Component => _cachedComponents.ContainsKey(typeof(T));
      //
      //
      //
      // private bool TryGetCached<T>(out object cachedComponent) where T : Component => _cachedComponents.TryGetValue(typeof(T), out cachedComponent);
      //
      // private T GetAndCache<T>() where T : Component {
      //    T component = GetComponent<T>();
      //    _cachedComponents[typeof(T)] = component;
      //    return component;
      // }
   }
}