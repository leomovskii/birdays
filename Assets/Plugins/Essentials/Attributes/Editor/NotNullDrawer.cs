using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Essentials {
	[CustomPropertyDrawer(typeof(NotNullAttribute))]
	public class NotNullDrawer : PropertyDrawer {

		private readonly static string WarnMessageTemplate = "NotNull doesn't support the property type {0}.";
		private readonly static string ErrorMessageTemplate = "Field {0} is null or empty.";
		private readonly static float HelpBoxHeight = 40f;

		private bool _helpboxDrawn = false;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			return EditorGUI.GetPropertyHeight(property, label, true) + (_helpboxDrawn ? HelpBoxHeight : 0f);
		}

		private bool IsNull(SerializedProperty property) {
			return property.propertyType switch {
				SerializedPropertyType.String => string.IsNullOrEmpty(property.stringValue),
				SerializedPropertyType.ObjectReference => property.objectReferenceValue == null,
				SerializedPropertyType.ExposedReference => property.exposedReferenceValue == null,
#if UNITY_2021_2_OR_NEWER
				SerializedPropertyType.ManagedReference => property.managedReferenceValue == null,
#endif
				_ => false
			};
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			_helpboxDrawn = false;

			if (!IsPropertyTypeSupported(property.propertyType))
				position = DrawCustomHelpbox(position, string.Format(WarnMessageTemplate, property.propertyType), MessageType.Warning);
			else if (IsNull(property))
				position = DrawCustomHelpbox(position, string.Format(ErrorMessageTemplate, property.name), MessageType.Error);

			EditorGUI.PropertyField(position, property, label, true);
		}

		private Rect DrawCustomHelpbox(Rect position, string messageText, MessageType messageType) {
			_helpboxDrawn = true;
			var helpBoxRect = new Rect(position.xMin, position.yMin, position.width, position.height - HelpBoxHeight / 2);
			EditorGUI.HelpBox(helpBoxRect, messageText, messageType);
			position.yMin += HelpBoxHeight;
			return position;
		}

		private bool IsPropertyTypeSupported(SerializedPropertyType propertyType) {
			return propertyType == SerializedPropertyType.String
				|| propertyType == SerializedPropertyType.ObjectReference
				|| propertyType == SerializedPropertyType.ExposedReference
#if UNITY_2021_2_OR_NEWER
				|| propertyType == SerializedPropertyType.ManagedReference
#endif
				;
		}
	}
}
#endif