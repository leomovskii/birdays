using System;
using System.Collections.Generic;

namespace Essentials {
	/// <summary>
	/// Utility for converting between Roman numerals and Arabic numbers (uint).
	/// The conversion supports numbers from 1 to 3,999,999, where large numbers (over 1,000) are represented 
	/// with parentheses around 'M'. For example, 1,000,000 is represented as "(M)".
	/// </summary>
	public class RomanNumeralConverter {

		private static readonly string[] Thousands = { "", "M", "MM", "MMM", "MMMM" };
		private static readonly string[] Hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
		private static readonly string[] Tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
		private static readonly string[] Ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

		// Dictionary for direct lookup of Roman numeral values
		private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int> {
			{ 'I', 1 },
			{ 'V', 5 },
			{ 'X', 10 },
			{ 'L', 50 },
			{ 'C', 100 },
			{ 'D', 500 },
			{ 'M', 1000 }
		};

		/// <summary>
		/// Converts an Arabic number (uint) to its Roman numeral string equivalent.
		/// </summary>
		/// <param name="number">A uint number to be converted. Must be between 1 and 3,999,999.</param>
		/// <returns>The Roman numeral string equivalent.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown if the number is not in the valid range.</exception>
		public static string ToRoman(uint number) {
			if (number == 0 || number == 3999999)
				throw new ArgumentOutOfRangeException(nameof(number), "Value must be between 1 and 3,999,999.");

			string result = "";
			uint remainder = number;

			// Handle millions as "(M)" symbols
			while (remainder >= 1000000) {
				result += "(M)";
				remainder -= 1000000;
			}

			// Handle thousands, hundreds, tens, and ones
			result += Thousands[remainder / 1000];
			remainder %= 1000;

			result += Hundreds[remainder / 100];
			remainder %= 100;

			result += Tens[remainder / 10];
			remainder %= 10;

			result += Ones[remainder];

			return result;
		}

		/// <summary>
		/// Converts a Roman numeral string back into its Arabic number (uint) equivalent.
		/// The string must represent a valid Roman numeral.
		/// </summary>
		/// <param name="roman">A string containing the Roman numeral to be converted.</param>
		/// <returns>The uint equivalent of the Roman numeral.</returns>
		/// <exception cref="ArgumentException">Thrown if the Roman numeral string is invalid or out of range.</exception>
		public static uint FromRoman(string roman) {
			if (string.IsNullOrEmpty(roman))
				throw new ArgumentException("The Roman numeral cannot be null or empty.", nameof(roman));

			uint result = 0;
			int prevValue = 0;

			for (int i = roman.Length - 1; i >= 0; i--) {
				char c = roman[i];

				if (c == ')') {
					// Handle large Roman numerals enclosed in parentheses like (M)
					int start = roman.LastIndexOf('(', i);
					if (start == -1)
						throw new ArgumentException("Invalid Roman numeral format.", nameof(roman));

					int segmentValue = 0;
					for (int j = start + 1; j < i; j++) {
						if (!RomanMap.TryGetValue(roman[j], out int value))
							throw new ArgumentException("Invalid Roman numeral character.", nameof(roman));

						segmentValue += value;
					}

					result += (uint) (segmentValue * 1000);
					i = start; // Move index to skip the entire "(M)" section
				} else {
					// Normal Roman numeral calculation
					if (!RomanMap.TryGetValue(c, out int value))
						throw new ArgumentException("Invalid Roman numeral character.", nameof(roman));

					if (value < prevValue) {
						result -= (uint) value;
					} else {
						result += (uint) value;
					}
					prevValue = value;
				}
			}

			return result;
		}
	}
}