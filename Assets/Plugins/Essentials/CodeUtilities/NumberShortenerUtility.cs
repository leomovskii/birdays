using System.Linq;

namespace Essentials {
	public static class NumberShortenerUtility {

		private readonly static string[] _suffixes = { "", "K", "M", "G", "T", "Q", "P" };
		private static readonly double[] _thresholds = Enumerable.Range(0, _suffixes.Length).
			Select(i => System.Math.Pow(1000, i)).ToArray();

		public static string Short(double number, string format = "0", bool uppercase = true) {
			int index = 0;
			while (index < _suffixes.Length - 1 && System.Math.Abs(number) >= _thresholds[index + 1])
				index++;
			double formattedValue = number / _thresholds[index];
			return formattedValue.ToString(format) + (uppercase ? _suffixes[index] : _suffixes[index].ToLower());
		}
	}
}