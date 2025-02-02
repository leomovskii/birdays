using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Essentials {
	[CustomPropertyDrawer(typeof(RangeSliderAttribute))]
	public class RangeSliderDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			var range = (RangeSliderAttribute) attribute;

			if (property.propertyType == SerializedPropertyType.Vector2) {
				DrawVector2Slider(position, property, label, range);
			} else if (property.propertyType == SerializedPropertyType.Vector2Int) {
				DrawVector2IntSlider(position, property, label, range);
			} else {
				EditorGUI.LabelField(position, label.text, "Use RangeSlider with Vector2 or Vector2Int.");
			}
		}

		private void DrawVector2Slider(Rect position, SerializedProperty property, GUIContent label, RangeSliderAttribute range) {
			Vector2 value = property.vector2Value;

			float min = value.x;
			float max = value.y;

			EditorGUI.BeginProperty(position, label, property);

			EditorGUI.MinMaxSlider(position, label, ref min, ref max, range.Min, range.Max);

			value.x = Mathf.Clamp(min, range.Min, range.Max);
			value.y = Mathf.Clamp(max, range.Min, range.Max);

			property.vector2Value = value;

			EditorGUI.EndProperty();
		}

		private void DrawVector2IntSlider(Rect position, SerializedProperty property, GUIContent label, RangeSliderAttribute range) {
			Vector2Int value = property.vector2IntValue;

			float min = value.x;
			float max = value.y;

			EditorGUI.BeginProperty(position, label, property);

			EditorGUI.MinMaxSlider(position, label, ref min, ref max, range.Min, range.Max);

			value.x = Mathf.RoundToInt(Mathf.Clamp(min, range.Min, range.Max));
			value.y = Mathf.RoundToInt(Mathf.Clamp(max, range.Min, range.Max));

			property.vector2IntValue = value;

			EditorGUI.EndProperty();
		}
	}
}
#endif