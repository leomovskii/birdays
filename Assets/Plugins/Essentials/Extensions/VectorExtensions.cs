using UnityEngine;

namespace Essentials {
	public static class VectorExtensions {

		/// <summary>
		/// Calculates the distance between two Vector3 points, with options to ignore any combination of the x, y, or z coordinates.
		/// </summary>
		/// <param name="origin">The starting point for the distance calculation.</param>
		/// <param name="target">The ending point for the distance calculation.</param>
		/// <param name="ignoreX">If set to true, the x-coordinate difference will be ignored.</param>
		/// <param name="ignoreY">If set to true, the y-coordinate difference will be ignored.</param>
		/// <param name="ignoreZ">If set to true, the z-coordinate difference will be ignored.</param>
		/// <returns>The distance between the two points, ignoring the specified coordinates.</returns>
		public static float DistanceFlat(this Vector3 origin, Vector3 target, bool? ignoreX = null, bool? ignoreY = null, bool? ignoreZ = null) {
			float dx = ignoreX != null && ignoreX.Value ? 0 : origin.x - target.x;
			float dy = ignoreY != null && ignoreY.Value ? 0 : origin.y - target.y;
			float dz = ignoreZ != null && ignoreZ.Value ? 0 : origin.z - target.z;
			return Mathf.Sqrt(dx * dx + dy * dy + dz * dz);
		}

		/// <summary>
		/// Adds a Vector2 to a Vector3, and returns a new Vector3.
		/// </summary>
		/// <param name="origin">The Vector2 to add.</param>
		/// <param name="toAdd">The Vector3 that the Vector2 is added to.</param>
		/// <returns>The resulting Vector3.</returns>
		public static Vector3 Add(this Vector2 origin, Vector3 toAdd) {
			toAdd.x += origin.x;
			toAdd.y += origin.y;
			return toAdd;
		}

		/// <summary>
		/// Adds a Vector2 to a Vector4, and returns a new Vector4.
		/// </summary>
		/// <param name="origin">The Vector2 to add.</param>
		/// <param name="toAdd">The Vector4 that the Vector2 is added to.</param>
		/// <returns>The resulting Vector4.</returns>
		public static Vector4 Add(this Vector2 origin, Vector4 toAdd) {
			toAdd.x += origin.x;
			toAdd.y += origin.y;
			return toAdd;
		}

		/// <summary>
		/// Adds a Vector3 to a Vector4, and returns a new Vector4.
		/// </summary>
		/// <param name="origin">The Vector3 to add.</param>
		/// <param name="toAdd">The Vector4 that the Vector3 is added to.</param>
		/// <returns>The resulting Vector4.</returns>
		public static Vector4 Add(this Vector3 origin, Vector4 toAdd) {
			toAdd.x += origin.x;
			toAdd.y += origin.y;
			toAdd.z += origin.z;
			return toAdd;
		}

		public static float Random(this Vector2 origin) {
			return UnityEngine.Random.Range(origin.x, origin.y);
		}

		public static int Random(this Vector2Int origin) {
			return UnityEngine.Random.Range(origin.x, origin.y);
		}

		public static float Clamp(this Vector2 origin, float value) {
			return value < origin.x ? origin.x : (value > origin.y ? origin.y : value);
		}

		public static int Clamp(this Vector2Int origin, int value) {
			return value < origin.x ? origin.x : (value > origin.y ? origin.y : value);
		}
	}
}
