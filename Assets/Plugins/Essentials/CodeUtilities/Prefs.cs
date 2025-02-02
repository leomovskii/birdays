using System;
using System.Globalization;
using UnityEngine;

namespace Essentials {
	public static class Prefs {
		#region Bool
		/// <summary>
		/// Retrieves a boolean value from PlayerPrefs.
		/// </summary>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value if the key does not exist.</param>
		/// <returns>Returns true or false based on the stored value.</returns>
		public static bool GetBool(string key, bool defaultValue = false) {
			return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
		}

		/// <summary>
		/// Stores a boolean value in PlayerPrefs.
		/// </summary>
		/// <param name="key">The key to store the value under.</param>
		/// <param name="value">The boolean value to store.</param>
		public static void SetBool(string key, bool value) {
			PlayerPrefs.SetInt(key, value ? 1 : 0);
		}
		#endregion
		#region Int (adapter)
		/// <summary>
		/// Retrieves a int value from PlayerPrefs.
		/// </summary>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value if the key does not exist.</param>
		/// <returns>Returns the stored int value or the default value.</returns>
		public static int GetInt(string key, int defaultValue = 0) {
			return PlayerPrefs.GetInt(key, defaultValue);
		}

		/// <summary>
		/// Stores a int value in PlayerPrefs.
		/// </summary>
		/// <param name="key">The key to store the value under.</param>
		/// <param name="value">The int value to store.</param>
		public static void SetInt(string key, int value) {
			PlayerPrefs.SetInt(key, value);
		}
		#endregion
		#region Long
		/// <summary>
		/// Retrieves a long value from PlayerPrefs.
		/// </summary>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value if the key does not exist.</param>
		/// <returns>Returns the stored long value or the default value.</returns>
		public static long GetLong(string key, long defaultValue = 0L) {
			try {
				var data = PlayerPrefs.GetString(key, defaultValue.ToString(CultureInfo.InvariantCulture));
				return long.Parse(data, CultureInfo.InvariantCulture);

			} catch (FormatException) {
				return 0L;
			}
		}

		/// <summary>
		/// Stores a long value in PlayerPrefs.
		/// </summary>
		/// <param name="key">The key to store the value under.</param>
		/// <param name="value">The long value to store.</param>
		public static void SetLong(string key, long value) {
			PlayerPrefs.SetString(key, value.ToString(CultureInfo.InvariantCulture));
		}
		#endregion
		#region Float (adapter)
		/// <summary>
		/// Retrieves a float value from PlayerPrefs.
		/// </summary>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value if the key does not exist.</param>
		/// <returns>Returns the stored float value or the default value.</returns>
		public static float GetFloat(string key, float defaultValue = 0f) {
			return PlayerPrefs.GetFloat(key, defaultValue);
		}

		/// <summary>
		/// Stores a float value in PlayerPrefs.
		/// </summary>
		/// <param name="key">The key to store the value under.</param>
		/// <param name="value">The float value to store.</param>
		public static void SetFloat(string key, float value) {
			PlayerPrefs.SetFloat(key, value);
		}
		#endregion
		#region Double
		/// <summary>
		/// Retrieves a double value from PlayerPrefs.
		/// </summary>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value if the key does not exist.</param>
		/// <returns>Returns the stored double value or the default value.</returns>
		public static double GetDouble(string key, double defaultValue = 0.0) {
			try {
				var data = PlayerPrefs.GetString(key, defaultValue.ToString(CultureInfo.InvariantCulture));
				return double.Parse(data, CultureInfo.InvariantCulture);

			} catch (FormatException) {
				return 0.0;
			}
		}

		/// <summary>
		/// Stores a double value in PlayerPrefs.
		/// </summary>
		/// <param name="key">The key to store the value under.</param>
		/// <param name="value">The double value to store.</param>
		public static void SetDouble(string key, double value) {
			PlayerPrefs.SetString(key, value.ToString(CultureInfo.InvariantCulture));
		}
		#endregion
		#region Uint
		/// <summary>
		/// Retrieves a uint value from PlayerPrefs.
		/// </summary>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value if the key does not exist.</param>
		/// <returns>Returns the stored uint value or the default value.</returns>
		public static uint GetUint(string key, uint defaultValue = 0u) {
			try {
				var data = PlayerPrefs.GetString(key, defaultValue.ToString(CultureInfo.InvariantCulture));
				return uint.Parse(data, CultureInfo.InvariantCulture);

			} catch (FormatException) {
				return 0;
			}
		}

		/// <summary>
		/// Stores a uint value in PlayerPrefs.
		/// </summary>
		/// <param name="key">The key to store the value under.</param>
		/// <param name="value">The uint value to store.</param>
		public static void SetUint(string key, uint value) {
			PlayerPrefs.SetString(key, value.ToString(CultureInfo.InvariantCulture));
		}
		#endregion
		#region Ulong
		/// <summary>
		/// Retrieves a ulong value from PlayerPrefs.
		/// </summary>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value if the key does not exist.</param>
		/// <returns>Returns the stored ulong value or the default value.</returns>
		public static ulong GetUlong(string key, ulong defaultValue = 0L) {
			try {
				var data = PlayerPrefs.GetString(key, defaultValue.ToString(CultureInfo.InvariantCulture));
				return ulong.Parse(data, CultureInfo.InvariantCulture);

			} catch (FormatException) {
				return 0L;
			}
		}

		/// <summary>
		/// Stores a ulong value in PlayerPrefs.
		/// </summary>
		/// <param name="key">The key to store the value under.</param>
		/// <param name="value">The ulong value to store.</param>
		public static void SetUlong(string key, ulong value) {
			PlayerPrefs.SetString(key, value.ToString(CultureInfo.InvariantCulture));
		}
		#endregion
		#region String (adapter)
		/// <summary>
		/// Retrieves a string value from PlayerPrefs.
		/// </summary>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value if the key does not exist.</param>
		/// <returns>Returns the stored string value or the default value.</returns>
		public static string GetString(string key, string defaultValue = "") {
			return PlayerPrefs.GetString(key, defaultValue);
		}

		/// <summary>
		/// Stores a string value in PlayerPrefs.
		/// </summary>
		/// <param name="key">The key to store the value under.</param>
		/// <param name="value">The string value to store.</param>
		public static void SetString(string key, string value) {
			PlayerPrefs.SetString(key, value.ToString(CultureInfo.InvariantCulture));
		}
		#endregion
		#region Enum
		/// <summary>
		/// Retrieves an enum value from PlayerPrefs.
		/// </summary>
		/// <typeparam name="T">The type of the enum to retrieve.</typeparam>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value to return if the key does not exist or parsing fails.</param>
		/// <returns>Returns the stored enum value of type T or the default value.</returns>
		public static T GetEnum<T>(string key, T defaultValue) where T : Enum {
			try {
				var data = PlayerPrefs.GetString(key, defaultValue.ToString());
				return (T) Enum.Parse(typeof(T), data);
			} catch (ArgumentException) {
				return defaultValue;
			}
		}

		/// <summary>
		/// Stores an enum value in PlayerPrefs.
		/// </summary>
		/// <typeparam name="T">The type of the enum to store.</typeparam>
		/// <param name="key">The key under which the value will be stored.</param>
		/// <param name="value">The enum value to store.</param>
		public static void SetEnum<T>(string key, T value) where T : Enum {
			PlayerPrefs.SetString(key, value.ToString());
		}
		#endregion
		#region Array
		/// <summary>
		/// A helper class to wrap an array for serialization purposes.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		[Serializable]
		private class ArrayWrapper<T> {
			public T[] Array;
		}

		/// <summary>
		/// Retrieves an array of values from PlayerPrefs by deserializing it from JSON.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default array to return if the key does not exist or deserialization fails.</param>
		/// <returns>Returns the stored array of type T or the default array.</returns>
		public static T[] GetArray<T>(string key, T[] defaultValue = null) {
			try {
				var json = PlayerPrefs.GetString(key, JsonUtility.ToJson(new ArrayWrapper<T> { Array = defaultValue }));
				var wrapper = JsonUtility.FromJson<ArrayWrapper<T>>(json);
				return wrapper?.Array ?? defaultValue;
			} catch {
				return defaultValue;
			}
		}

		/// <summary>
		/// Stores an array of values in PlayerPrefs by serializing it to JSON.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="key">The key under which the array will be stored.</param>
		/// <param name="value">The array of values to store.</param>
		public static void SetArray<T>(string key, T[] value) {
			var wrapper = new ArrayWrapper<T> { Array = value };
			var json = JsonUtility.ToJson(wrapper);
			PlayerPrefs.SetString(key, json);
		}
		#endregion
		#region Generic/JSON
		/// <summary>
		/// Retrieves a value of type T from PlayerPrefs by deserializing it from JSON.
		/// </summary>
		/// <typeparam name="T">The type of the value to retrieve.</typeparam>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value if the key does not exist.</param>
		/// <returns>Returns the deserialized value of type T or the default value.</returns>
		public static T Get<T>(string key, T defaultValue = default) {
			try {
				var data = PlayerPrefs.GetString(key, defaultValue.ToString());
				return JsonUtility.FromJson<T>(data);

			} catch (FormatException) {
				return default;
			}
		}

		/// <summary>
		/// Stores a value of type T in PlayerPrefs by serializing it to JSON.
		/// </summary>
		/// <typeparam name="T">The type of the value to store.</typeparam>
		/// <param name="key">The key to store the value under.</param>
		/// <param name="value">The value to store.</param>
		public static void Set<T>(string key, T value) {
			PlayerPrefs.SetString(key, JsonUtility.ToJson(value));
		}
		#endregion
		#region Binary
		/// <summary>
		/// Retrieves binary data from PlayerPrefs by decoding it from a Base64 string.
		/// </summary>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default byte array to return if the key does not exist or decoding fails.</param>
		/// <returns>Returns the stored binary data as a byte array, or the default value if decoding fails.</returns>
		public static byte[] GetBinary(string key, byte[] defaultValue = null) {
			try {
				var base64 = PlayerPrefs.GetString(key, null);
				return string.IsNullOrEmpty(base64) ? defaultValue : Convert.FromBase64String(base64);
			} catch {
				return defaultValue;
			}
		}

		/// <summary>
		/// Stores binary data in PlayerPrefs by encoding it as a Base64 string.
		/// </summary>
		/// <param name="key">The key under which the binary data will be stored.</param>
		/// <param name="data">The binary data to store as a byte array.</param>
		public static void SetBinary(string key, byte[] data) {
			var base64 = Convert.ToBase64String(data);
			PlayerPrefs.SetString(key, base64);
		}
		#endregion
		#region DateTime
		private readonly static string FormatDateTime = "yyyy-MM-dd HH:mm:ss";
		private readonly static string FormatDate = "yyyy-MM-dd";
		private readonly static string FormatTime = "HH:mm:ss";

		/// <summary>Specifies the available time formats.</summary>
		public enum TimeFormat {
			DateTime, Date, Time24
		}

		public static string ToString(this TimeFormat origin) {
			return origin switch {
				TimeFormat.DateTime => FormatDateTime,
				TimeFormat.Date => FormatDate,
				TimeFormat.Time24 => FormatTime,
				_ => FormatDateTime
			};
		}

		/// <summary>
		/// Retrieves a DateTime value from PlayerPrefs.
		/// </summary>
		/// <param name="key">The key of the preference to retrieve.</param>
		/// <param name="defaultValue">The default value if the key does not exist.</param>
		/// <param name="timeFormat">The time format used to parse the stored value.</param>
		/// <returns>Returns the stored DateTime value or the default value.</returns>
		public static DateTime GetDateTime(string key, DateTime defaultValue, TimeFormat timeFormat) {
			string data = PlayerPrefs.GetString(key);
			return !string.IsNullOrEmpty(data) &&
				DateTime.TryParseExact(data, timeFormat.ToString(), CultureInfo.InvariantCulture,
				DateTimeStyles.None, out DateTime dateTime) ? dateTime : defaultValue;
		}

		/// <summary>
		/// Stores a DateTime value in PlayerPrefs.
		/// </summary>
		/// <param name="key">The key to store the value under.</param>
		/// <param name="value">The DateTime value to store.</param>
		/// <param name="timeFormat">The time format to use for storing the value.</param>
		public static void SetDateTime(string key, DateTime value, TimeFormat timeFormat) {
			string data = value.ToString(timeFormat.ToString());
			PlayerPrefs.SetString(key, data);
		}
		#endregion
	}
}
