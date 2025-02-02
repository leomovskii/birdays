using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace Essentials {
	public static class UIExtensions {

		/// <summary>
		/// Simple way to add callback to toggle with filter.
		/// </summary>
		public static void AddCallback(this Toggle origin, Action callback, bool condition = true) {
			if (callback != null)
				origin.onValueChanged.AddListener(e => {
					if (e == condition)
						callback?.Invoke();
				});
			else
				Debug.LogWarning("Can't add empty callback.");
		}

		/// <summary>
		/// Simple way to add callback to button.
		/// </summary>
		public static void AddCallback(this Button origin, Action callback) {
			if (callback != null)
				origin.onClick.AddListener(() => callback());
			else
				Debug.LogWarning("Can't add empty callback.");
		}

		/// <summary>
		/// Get Toggle list of group, using reflection for field 'm_Toggles'.
		/// </summary>
		public static List<Toggle> GetToggles(this ToggleGroup toggleGroup) {
			var toggleGroupType = typeof(ToggleGroup);

			var mTogglesField = toggleGroupType.GetField("m_Toggles", BindingFlags.NonPublic | BindingFlags.Instance);

			if (mTogglesField != null) {
				var toggles = mTogglesField.GetValue(toggleGroup) as List<Toggle>;
				return toggles ?? new List<Toggle>();
			}

			return new List<Toggle>();
		}
	}
}