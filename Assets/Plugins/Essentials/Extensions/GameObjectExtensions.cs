using UnityEngine;

namespace Essentials {
	public static class GameObjectExtensions {

		public static bool TryGetRandomChildOfType<T>(this GameObject origin, out T randomChild, bool includeInactive = false) where T : Component {
			var allOfType = origin.GetComponentsInChildren<T>(includeInactive);
			if (allOfType == null || allOfType.Length == 0) {
				randomChild = default;
				return false;
			}
			randomChild = allOfType[Random.Range(0, allOfType.Length)];
			return true;
		}

		/// <summary>
		/// Checks if a GameObject's layer matches with the provided LayerMask.
		/// </summary>
		/// <param name="origin">The GameObject to check.</param>
		/// <param name="mask">The LayerMask to match against the GameObject's layer.</param>
		/// <returns>True if the GameObject's layer is included in the LayerMask; otherwise, false.</returns>
		public static bool MatchMask(this GameObject origin, LayerMask mask) {
			return (mask.value & (1 << origin.layer)) > 0;
		}

		/// <summary>
		/// Retrieves the component of the specified type from the GameObject. If the component doesn't exist, a new one is added and returned.
		/// </summary>
		/// <typeparam name="T">The type of Component to retrieve or add.</typeparam>
		/// <param name="origin">The GameObject from which to retrieve or add the component.</param>
		/// <returns>The existing component of the specified type if found, otherwise the newly added component.</returns>
		public static T GetOrAddComponent<T>(this GameObject origin) where T : Component {
			return origin.GetComponent<T>() ?? origin.AddComponent<T>();
		}
	}
}