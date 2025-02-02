using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Essentials {
	[CustomPropertyDrawer(typeof(MinMaxAttribute))]
	class MinMaxDrawer : PropertyDrawer {

		private readonly static float LabelWidth = 30f;
		private readonly static float DeltaWidth = 2f;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			EditorGUI.BeginProperty(position, label, property);

			if (property.propertyType == SerializedPropertyType.Vector2) {
				DrawMinMaxVector2(position, property, label);
			} else if (property.propertyType == SerializedPropertyType.Vector2Int) {
				DrawMinMaxVector2Int(position, property, label);
			} else {
				EditorGUI.LabelField(position, label.text, "Use MinMax with Vector2 or Vector2Int only.");
			}

			EditorGUI.EndProperty();
		}

		private void DrawMinMaxVector2(Rect position, SerializedProperty property, GUIContent label) {
			float realWidth = position.width;

			position = EditorGUI.PrefixLabel(position, label);

			float originalLabelWidth = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = LabelWidth;

			float remainingWidth = realWidth - originalLabelWidth;
			float fieldWidth = remainingWidth / 2 - DeltaWidth;

			Vector2 vector = property.vector2Value;
			vector.x = EditorGUI.FloatField(new Rect(position.x, position.y, fieldWidth, position.height), "Min", vector.x);
			vector.y = EditorGUI.FloatField(new Rect(position.x + fieldWidth + DeltaWidth, position.y, fieldWidth, position.height), "Max", vector.y);

			if (vector.y < vector.x)
				vector.y = vector.x;

			property.vector2Value = vector;
			EditorGUIUtility.labelWidth = originalLabelWidth;
		}

		private void DrawMinMaxVector2Int(Rect position, SerializedProperty property, GUIContent label) {
			float realWidth = position.width;

			position = EditorGUI.PrefixLabel(position, label);

			float originalLabelWidth = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = LabelWidth;

			float remainingWidth = realWidth - originalLabelWidth;
			float fieldWidth = remainingWidth / 2 - DeltaWidth;

			Vector2Int vector = property.vector2IntValue;
			vector.x = EditorGUI.IntField(new Rect(position.x, position.y, fieldWidth, position.height), "Min", vector.x);
			vector.y = EditorGUI.IntField(new Rect(position.x + fieldWidth + DeltaWidth, position.y, fieldWidth, position.height), "Max", vector.y);

			if (vector.y < vector.x)
				vector.y = vector.x;

			property.vector2IntValue = vector;
			EditorGUIUtility.labelWidth = originalLabelWidth;
		}
	}
}
#endif