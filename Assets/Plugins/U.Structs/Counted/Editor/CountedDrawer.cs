using UnityEditor;
using UnityEngine;

namespace Structs.Counted.Editor {
   [CustomPropertyDrawer(typeof(Counted<>), useForChildren: true)]
   public class CountedDrawer : PropertyDrawer {
      private const string _VALUE = "value";
      private const string _COUNT = "count";
      private const int    _WIDTH = 24 * 2;

      public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
         SerializedProperty lootProp  = property.FindPropertyRelative(_VALUE);
         SerializedProperty countProp = property.FindPropertyRelative(_COUNT);


         position.width -= _WIDTH;
         EditorGUI.PropertyField(position, lootProp, label, includeChildren: true);

         position.x      += position.width + _WIDTH;
         position.width  =  _WIDTH;
         position.height =  EditorGUI.GetPropertyHeight(lootProp);
         position.x      -= position.width;
         EditorGUI.PropertyField(position, countProp, GUIContent.none);
      }
   }
}