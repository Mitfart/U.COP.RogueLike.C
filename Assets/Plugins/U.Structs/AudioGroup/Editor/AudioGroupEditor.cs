using UnityEditor;
using UnityEngine;

namespace AudioGroup.Editor {
   [CanEditMultipleObjects, CustomEditor(typeof(AudioGroup), editorForChildClasses: true)]
   public class AudioGroupEditor : UnityEditor.Editor {
      private const string _PLAY_PREVIEW = "Preview";
      private const float  _GAP          = 20f;

      private static AudioSource _testAudioSource;



      public override void OnInspectorGUI() {
         if (target is not AudioGroup audioEvent)
            return;

         DrawDefaultInspector();

         GUILayout.Space(_GAP);

         if (GUILayout.Button(_PLAY_PREVIEW))
            audioEvent.Play(TestAudioSource());
      }



      private static AudioSource TestAudioSource() => _testAudioSource ??= CreateTestAudioSource();

      private static AudioSource CreateTestAudioSource()
         => new GameObject { hideFlags = HideFlags.HideInHierarchy }
           .AddComponent<AudioSource>();
   }
}