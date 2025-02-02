using UnityEngine;

namespace Essentials {
	public static class TransformExtensions {

		/// <summary>
		/// Rotates the Transform to look at the 2D position of a target Transform.
		/// </summary>
		/// <param name="origin">The Transform to rotate.</param>
		/// <param name="target">The target Transform to look at.</param>
		public static void LookAt2D(this Transform origin, Transform target) {
			origin.LookAt2D(target, Vector2.up);
		}

		/// <summary>
		/// Rotates the Transform to look at the 2D position of a target Transform, with a specified forward direction.
		/// </summary>
		/// <param name="origin">The Transform to rotate.</param>
		/// <param name="target">The target Transform to look at.</param>
		/// <param name="forwardDirection">The vector that defines the forward direction.</param>
		public static void LookAt2D(this Transform origin, Transform target, Vector2 forwardDirection) {
			Vector2 difference = target.position - origin.position;
			float angleToTarget = Mathf.Atan2(difference.y, difference.x);
			float angleForward = Mathf.Atan2(forwardDirection.y, forwardDirection.x);
			float rotationZ = Mathf.Rad2Deg * (angleToTarget - angleForward);
			origin.rotation = Quaternion.Euler(0f, 0f, rotationZ);
		}

		/// <summary>
		/// Resets the Transform's position, rotation, and scale to default values.
		/// </summary>
		/// <param name="origin">The Transform to reset.</param>
		/// <param name="resetLocal">If set to true, the local position and rotation will be reset instead of the global position and rotation.</param>
		public static void Reset(this Transform origin, bool resetLocal = false) {
			if (resetLocal) {
#if UNITY_2022_1_OR_NEWER
				origin.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
#else
				origin.localPosition = Vector3.zero;
				origin.localRotation = Quaternion.identity;
#endif
			} else
				origin.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			origin.localScale = Vector3.one;
		}
	}
}