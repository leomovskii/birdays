using System;
using System.Collections.Generic;
using System.Linq;

namespace Essentials {
	public static class CollectionsExtensions {

		#region IEnumerable

		/// <summary>
		/// Attempts to get a specified number of random elements from the provided enumerable.
		/// </summary>
		/// <typeparam name="T">The type of elements in the enumerable.</typeparam>
		/// <param name="origin">The enumerable to get random elements from.</param>
		/// <param name="random">The list to store the random elements.</param>
		/// <param name="countOfElements">The number of random elements to get. Default is 1.</param>
		/// <returns>True if the operation is successful; otherwise, false.</returns>
		public static bool TryGetRandomElements<T>(this IEnumerable<T> origin, out List<T> random, int countOfElements = 1) {
			if (!origin.Any()) {
				random = default;
				return false;
			}

			var _random = new Random();

			countOfElements = Math.Min(countOfElements, origin.Count());
			random = origin.OrderBy(x => _random.Next()).Take(countOfElements).ToList();

			return true;
		}

		#endregion

		#region IList

		/// <summary>
		/// Checks whether the list contains an element at the specified index.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="origin">The list to check.</param>
		/// <param name="index">The index to check in the list.</param>
		/// <returns>True if the index is within the bounds of the list; otherwise, false.</returns>
		public static bool ContainsIndex<T>(this IList<T> origin, int index) {
			return origin.Any() && index >= 0 && index < origin.Count();
		}

		/// <summary>
		/// Checks whether the list contains elements at all the specified indexes.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="origin">The list to check.</param>
		/// <param name="indexes">The indexes to check in the list.</param>
		/// <returns>True if all indexes are within the bounds of the list; otherwise, false.</returns>
		public static bool ContainsAllIndexes<T>(this IList<T> origin, params int[] indexes) {
			if (!origin.Any() || !indexes.Any())
				return false;
			int size = origin.Count();
			return indexes.All(index => index >= 0 && index < size);
		}

		/// <summary>
		/// Shuffles the elements of the list randomly.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="origin">The list of elements to be shuffled.</param>
		/// <param name="iterationsCount">The number of iterations to perform the shuffle. If null, the list is shuffled completely using the Fisher-Yates algorithm. 
		/// If a positive value is provided, it will shuffle the list that many times. If the value is less than or equal to 0, the shuffle will be done using the full list size.</param>
		/// <returns>Returns true if the list was shuffled successfully, false if the list is empty.</returns>
		public static bool Shuffle<T>(this IList<T> origin, int? iterationsCount) {
			if (!origin.Any())
				return false;

			var _random = new Random();

			if (iterationsCount == null) {
				for (int i = origin.Count - 1; i > 0; i--) {
					int j = _random.Next(i + 1);
					(origin[i], origin[j]) = (origin[j], origin[i]);
				}

			} else {
				int realIterationsCount = iterationsCount <= 0 ? origin.Count : iterationsCount.Value;
				for (int i = 0; i < realIterationsCount; i++) {
					int j = _random.Next(i, realIterationsCount);
					(origin[i], origin[j]) = (origin[j], origin[i]);
				}
			}

			return true;
		}

		/// <summary>
		/// Swaps two elements in the list at the specified indexes.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="origin">The list to perform the swap in.</param>
		/// <param name="i">The index of the first element to swap.</param>
		/// <param name="j">The index of the second element to swap.</param>
		/// <returns>True if the swap is successful; otherwise, false.</returns>
		public static bool Swap<T>(this IList<T> origin, int i, int j) {
			if (!origin.Any() || !origin.ContainsAllIndexes(i, j))
				return false;

			(origin[i], origin[j]) = (origin[j], origin[i]);

			return true;
		}

		/// <summary>
		/// Attempts to get a random element from the list.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="origin">The list to get a random element from.</param>
		/// <param name="random">The variable to store the random element.</param>
		/// <returns>True if a random element is successfully retrieved; otherwise, false.</returns>
		public static bool TryGetRandom<T>(this IList<T> origin, out T random) {
			if (!origin.Any()) {
				random = default;
				return false;
			}

			random = origin[UnityEngine.Random.Range(0, origin.Count)];
			return true;
		}

		#endregion

		#region IDictionary

		/// <summary>
		/// Attempts to add a new key with a value to the dictionary, or increases the value if the key already exists.
		/// </summary>
		/// <typeparam name="T">The type of keys in the dictionary.</typeparam>
		/// <param name="origin">The dictionary to add to or increase the value in.</param>
		/// <param name="key">The key for the value to add or increase.</param>
		/// <param name="amount">The amount to add or increase the value by.</param>
		/// <param name="totalAmount">The total amount after addition or increase.</param>
		/// <returns>True if the operation is successful; otherwise, false.</returns>
		public static bool TryAddOrIncrease<T>(this IDictionary<T, int> origin, T key, int amount, out int totalAmount) {
			if (origin == null) {
				totalAmount = 0;
				return false;
			}

			if (!origin.ContainsKey(key))
				origin.Add(key, amount);
			else
				origin[key] += amount;

			totalAmount = origin[key];
			return true;
		}

		/// <summary>
		/// Attempts to add a new key with a value to the dictionary, or increases the value if the key already exists.
		/// </summary>
		/// <typeparam name="T">The type of keys in the dictionary.</typeparam>
		/// <param name="origin">The dictionary to add to or increase the value in.</param>
		/// <param name="key">The key for the value to add or increase.</param>
		/// <param name="amount">The amount to add or increase the value by.</param>
		/// <param name="totalAmount">The total amount after addition or increase.</param>
		/// <returns>True if the operation is successful; otherwise, false.</returns>
		public static bool AddOrIncrease<T>(this IDictionary<T, float> origin, T key, float amount, out float totalAmount) {
			if (origin == null) {
				totalAmount = 0f;
				return false;
			}

			if (!origin.ContainsKey(key))
				origin.Add(key, amount);
			else
				origin[key] += amount;

			totalAmount = origin[key];
			return true;
		}

		/// <summary>
		/// Attempts to add a new key with a value to the dictionary, or increases the value if the key already exists.
		/// </summary>
		/// <typeparam name="T">The type of keys in the dictionary.</typeparam>
		/// <param name="origin">The dictionary to add to or increase the value in.</param>
		/// <param name="key">The key for the value to add or increase.</param>
		/// <param name="amount">The amount to add or increase the value by.</param>
		/// <param name="totalAmount">The total amount after addition or increase.</param>
		/// <returns>True if the operation is successful; otherwise, false.</returns>
		public static bool AddOrIncrease<T>(this IDictionary<T, long> origin, T key, long amount, out long totalAmount) {
			if (origin == null) {
				totalAmount = 0;
				return false;
			}

			if (!origin.ContainsKey(key))
				origin.Add(key, amount);
			else
				origin[key] += amount;

			totalAmount = origin[key];
			return true;
		}

		/// <summary>
		/// Attempts to add a new key with a value to the dictionary, or increases the value if the key already exists.
		/// </summary>
		/// <typeparam name="T">The type of keys in the dictionary.</typeparam>
		/// <param name="origin">The dictionary to add to or increase the value in.</param>
		/// <param name="key">The key for the value to add or increase.</param>
		/// <param name="amount">The amount to add or increase the value by.</param>
		/// <param name="totalAmount">The total amount after addition or increase.</param>
		/// <returns>True if the operation is successful; otherwise, false.</returns>
		public static bool AddOrIncrease<T>(this IDictionary<T, double> origin, T key, double amount, out double totalAmount) {
			if (origin == null) {
				totalAmount = 0.0;
				return false;
			}

			if (!origin.ContainsKey(key))
				origin.Add(key, amount);
			else
				origin[key] += amount;

			totalAmount = origin[key];
			return true;
		}

		#endregion
	}
}