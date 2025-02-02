using System;
using UnityEngine;

namespace Essentials {
	public static class EnumExtensions {
		public static T GetRandomValue<T>(int startIndex = 0) where T : Enum {
			var values = Enum.GetValues(typeof(T));
			if (startIndex < 0 || startIndex >= values.Length) {
				Debug.LogError($"Function 'GetRandomValue' got invalid input for startIndex = {startIndex}. It will be ignored by resetting to 0.");
				startIndex = 0;
			}

			int randomIndex = UnityEngine.Random.Range(startIndex, values.Length);
			return (T) values.GetValue(randomIndex);
		}

		public static T GetRandomValue<T>(int startIndex, int endIndex) where T : Enum {
			var values = Enum.GetValues(typeof(T));
			if (startIndex < 0 || startIndex >= values.Length) {
				Debug.LogError($"Function 'GetRandomValue' got invalid input for startIndex = {startIndex}. It will be ignored by resetting to 0.");
				startIndex = 0;
			}

			if (endIndex < 0 || endIndex >= values.Length) {
				Debug.LogError($"Function 'GetRandomValue' got invalid input for endIndex = {startIndex}. It will be ignored by resetting to {values.Length - 1}.");
				endIndex = values.Length - 1;
			}

			int randomIndex = UnityEngine.Random.Range(startIndex, endIndex);
			return (T) values.GetValue(randomIndex);
		}
	}
}