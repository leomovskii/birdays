using UnityEngine;

namespace Birdays {
	public static class Utility {

		private readonly static string[] MonthsFull = { "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december", };

		private readonly static string[] MonthsShort = { "jan.", "feb.", "mar.", "apr.", "may", "june", "july", "aug.", "sep.", "oct.", "nov.", "dec.", };

		public static string GetMonth(int index, bool isShort) {
			return (isShort ? MonthsShort : MonthsFull)[index];
		}

		public static Color GetYearsBackgroundColor(bool wasDisplaying) {
			return wasDisplaying ? new Color(Random.value, Random.value, Random.value, 1f) : Color.clear;
		}

		public static string GetNumericText(int number, string normal) {
			return number == 1 ? $"{number}{normal}" : $"{number}{normal}s";
		}
	}
}