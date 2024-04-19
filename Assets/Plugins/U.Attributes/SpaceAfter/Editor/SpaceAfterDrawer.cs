using UnityEditor;
using UnityEngine;

namespace Attributes.ReadOnly.Editor {
   [CustomPropertyDrawer(typeof(SpaceAfterAttribute))]
   public class SpaceAfterDrawer : PropertyDrawer {
      public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
         => EditorGUI.PropertyField(position, property, label, true);

      public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
         => base.GetPropertyHeight(property, label) + Height();

      private float Height() //
         => attribute is SpaceAfterAttribute spaceAfter ? spaceAfter.height : 10f;
   }
}