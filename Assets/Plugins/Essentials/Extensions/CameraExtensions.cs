using UnityEngine;

namespace Essentials {
	public static class CameraExtensions {

		/// <summary>
		/// Determines whether the renderer's bounds are visible from the camera.
		/// </summary>
		/// <param name="origin">The camera from which to check visibility.</param>
		/// <param name="renderer">The renderer to check against the camera's frustum.</param>
		/// <returns>True if the renderer is within the camera's frustum, false otherwise.</returns>
		public static bool IsVisibleFrom(this Camera origin, Renderer renderer) {
			var planes = GeometryUtility.CalculateFrustumPlanes(origin);
			return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
		}

		/// <summary>
		/// Determines whether the collider's bounds are visible from the camera.
		/// </summary>
		/// <param name="origin">The camera from which to check visibility.</param>
		/// <param name="collider">The collider to check against the camera's frustum.</param>
		/// <returns>True if the collider is within the camera's frustum, false otherwise.</returns>
		public static bool IsVisibleFrom(this Camera origin, Collider collider) {
			var planes = GeometryUtility.CalculateFrustumPlanes(origin);
			return GeometryUtility.TestPlanesAABB(planes, collider.bounds);
		}

		/// <summary>
		/// Determines whether the 2D collider's bounds are visible from the camera.
		/// </summary>
		/// <param name="origin">The camera from which to check visibility.</param>
		/// <param name="collider">The 2D collider to check against the camera's frustum.</param>
		/// <returns>True if the 2D collider is within the camera's frustum, false otherwise.</returns>
		public static bool IsVisibleFrom(this Camera origin, Collider2D collider) {
			var planes = GeometryUtility.CalculateFrustumPlanes(origin);
			return GeometryUtility.TestPlanesAABB(planes, collider.bounds);
		}
	}
}