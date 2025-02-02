using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Essentials {
	[CustomPropertyDrawer(typeof(PreviewAttribute))]
	class SpritePreviewDrawer : PropertyDrawer {
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			var previewAttribute = (PreviewAttribute)attribute;
			if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue != null) {
				float aspectRatio = 1f;

				if (property.objectReferenceValue is Sprite sprite) {
					aspectRatio = sprite.rect.height / sprite.rect.width;
				} else if (property.objectReferenceValue is Texture2D texture2D) {
					aspectRatio = (float)texture2D.height / texture2D.width;
				} else if (property.objectReferenceValue is Texture texture) {
					aspectRatio = (float)texture.height / texture.width;
				}

				return EditorGUIUtility.singleLineHeight + previewAttribute.Size * aspectRatio;
			}

			return EditorGUIUtility.singleLineHeight;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			var previewAttribute = (PreviewAttribute)attribute;

			// Рисуем поле свойства
			var labelRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
			EditorGUI.PropertyField(labelRect, property, label);

			if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue != null) {
				Rect previewRect = new Rect(
					position.x,
					position.y + EditorGUIUtility.singleLineHeight,
					previewAttribute.Size,
					0
				);

				float aspectRatio = 1f;

				if (property.objectReferenceValue is Sprite sprite) {
					aspectRatio = sprite.rect.height / sprite.rect.width;
					previewRect.height = previewAttribute.Size * aspectRatio;

					Texture2D texture = sprite.texture;
					Rect textureRect = sprite.textureRect;
					var uvRect = new Rect(
						textureRect.x / texture.width,
						textureRect.y / texture.height,
						textureRect.width / texture.width,
						textureRect.height / texture.height
					);

					GUI.DrawTextureWithTexCoords(previewRect, texture, uvRect, true);

				} else if (property.objectReferenceValue is Texture2D texture2D) {
					aspectRatio = (float)texture2D.height / texture2D.width;
					previewRect.height = previewAttribute.Size * aspectRatio;
					GUI.DrawTexture(previewRect, texture2D, ScaleMode.ScaleToFit, true);

				} else if (property.objectReferenceValue is Texture texture) {
					aspectRatio = (float)texture.height / texture.width;
					previewRect.height = previewAttribute.Size * aspectRatio;
					GUI.DrawTexture(previewRect, texture, ScaleMode.ScaleToFit, true);
				}
			}
		}
	}
}
#endif
