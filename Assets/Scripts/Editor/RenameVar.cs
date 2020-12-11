using UnityEngine;
using UnityEditor;

namespace UnityEngine.Utilities
{
    [CustomPropertyDrawer(typeof(RenameAttribute))]
    public class RenameVar : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, new GUIContent((attribute as RenameAttribute).NewName));
        }
    }
}