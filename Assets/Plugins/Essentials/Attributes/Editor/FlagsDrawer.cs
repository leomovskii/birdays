using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
namespace Essentials {
	[CustomPropertyDrawer(typeof(FlagsAttribute))]
	public class FlagsAttributeDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);
		}
	}
}
#endif