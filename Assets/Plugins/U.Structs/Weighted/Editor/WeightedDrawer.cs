using UnityEditor;
using UnityEngine;

namespace Structs.Weighted.Editor {
   [CustomPropertyDrawer(typeof(Weighted<>))]
   public class WeightedDrawer : PropertyDrawer {
      private const string _VALUE  = "value";
      private const string _WEIGHT = "weight";
      private const int    _WIDTH  = 24 * 2;


      public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
         SerializedProperty lootProp   = property.FindPropertyRelative(_VALUE);
         SerializedProperty weightProp = property.FindPropertyRelative(_WEIGHT);

         position.width -= _WIDTH;
         EditorGUI.PropertyField(position, lootProp, label, includeChildren: true);

         position.x      += position.width + _WIDTH;
         position.width  =  _WIDTH;
         position.height =  EditorGUI.GetPropertyHeight(lootProp);
         position.x      -= position.width;
         EditorGUI.PropertyField(position, weightProp, GUIContent.none);
      }
   }
}