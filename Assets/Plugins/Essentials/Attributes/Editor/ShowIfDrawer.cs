#if UNITY_EDITOR
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Essentials {

	[CustomPropertyDrawer(typeof(ShowIfAttribute))]
	public class ShowIfDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			var showIf = (ShowIfAttribute) attribute;
			bool shouldShow = ShouldShow(property, showIf);
			if (shouldShow)
				EditorGUI.PropertyField(position, property, label, true);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			var showIf = (ShowIfAttribute) attribute;
			bool shouldShow = ShouldShow(property, showIf);
			return shouldShow ? EditorGUI.GetPropertyHeight(property, label, true) : 0;
		}

		private bool ShouldShow(SerializedProperty property, ShowIfAttribute showIf) {
			var target = GetParentObject(property);
			if (target == null)
				return false;

			var members = target.GetType().GetMember(showIf.Condition, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

			if (members.Any()) {
				var memberInfo = members[0];
				switch (memberInfo.MemberType) {
					case MemberTypes.Method:
					var method = (MethodInfo) memberInfo;
					return (bool) method.Invoke(target, null);

					case MemberTypes.Field:
					var field = (FieldInfo) memberInfo;
					return (bool) field.GetValue(target);

					case MemberTypes.Property:
					var propertyInfo = (PropertyInfo) memberInfo;
					return (bool) propertyInfo.GetValue(target);
				}
			}
			return false;
		}

		private object GetParentObject(SerializedProperty property) {
			var path = property.propertyPath.Replace(".Array.data[", "[");
			object obj = property.serializedObject.targetObject;
			var elements = path.Split('.');

			foreach (var element in elements.Take(elements.Length - 1))
				if (element.Contains("[")) {
					var elementName = element.Substring(0, element.IndexOf("["));
					var index = int.Parse(element.Substring(element.IndexOf("[")).Replace("[", "").Replace("]", ""));
					obj = GetValue(obj, elementName, index);
				} else
					obj = GetValue(obj, element);
			return obj;
		}

		private object GetValue(object source, string name, int index = -1) {
			if (source == null)
				return null;

			var type = source.GetType();
			var field = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			var property = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

			var value = field != null ? field.GetValue(source) : property?.GetValue(source);

			if (index >= 0 && value is System.Collections.IEnumerable enumerable) {
				var enumerator = enumerable.GetEnumerator();
				for (int i = 0; i <= index; i++)
					if (!enumerator.MoveNext())
						return null;
				return enumerator.Current;
			}

			return value;
		}
	}
}
#endif
