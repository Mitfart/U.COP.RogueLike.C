using System.Linq;
using UnityEngine;

namespace AudioGroup {
   public abstract class AudioGroup : ScriptableObject {
      [field: SerializeField] public AudioClip[] Clips { get; protected set; }



      public abstract void Play(AudioSource source, Vector3 position = default);

      protected bool HasClips()
         => Clips is {
            Length: > 0
         };



      protected virtual void OnValidate() => Clips = Clips.Where(clip => clip != default).ToArray();
   }
}