using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
namespace Essentials {
	[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
	class ReadOnlyDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			GUI.enabled = false;
			EditorGUI.PropertyField(position, property, label);
			GUI.enabled = true;
		}
	}
}
#endif