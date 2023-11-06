using _Debug.Changers;
using UnityEditor;
using UnityEngine;

namespace DebugTools.Changers.Editor {
   [CustomEditor(typeof(BaseChanger), editorForChildClasses: true)]
   public class MonoChangerEditor : UnityEditor.Editor {
      public override void OnInspectorGUI() {
         DrawDefaultInspector();

         if (target is not BaseChanger script)
            return;

         GUILayout.Space(pixels: 25f);
         GUILayout.BeginHorizontal();

         if (GUILayout.Button(nameof(BaseChanger.Change)))
            script.Change();
         if (GUILayout.Button(nameof(BaseChanger.Normalize)))
            script.Normalize();

         GUILayout.EndHorizontal();
      }
   }
}