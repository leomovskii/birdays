using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Essentials {
	public static class OtherExtensions {

		public static T Clamp<T>(this T origin, T max, T min) where T : IComparable<T> {
			return origin.CompareTo(max) > 0 ? max : origin.CompareTo(min) < 0 ? min : origin;
		}

		#region LayerMask

		public static bool Contains(this LayerMask origin, RaycastHit hit) {
			return ((1 << hit.transform.gameObject.layer) & origin) != 0;
		}

		public static bool Contains(this LayerMask origin, int layer) {
			return ((1 << layer) & origin) != 0;
		}

		#endregion
		#region Color

		public static string ToHex(this Color color) {
			return ColorUtility.ToHtmlStringRGBA(color);
		}

		#endregion
		#region MonoBehaviour

		public static void StartCoroutineSafe(this MonoBehaviour origin, ref Coroutine coroutine, IEnumerator routine) {
			if (coroutine != null)
				origin.StopCoroutine(coroutine);
			coroutine = origin.StartCoroutine(routine);
		}

		#endregion
		#region Particle system

		/// <summary>
		/// Enables or disables the emission of particles from a ParticleSystem.
		/// </summary>
		/// <param name="origin">The ParticleSystem to modify.</param>
		/// <param name="enabled">Pass true to enable emission; false to disable.</param>
		public static void ToggleEmission(this ParticleSystem origin, bool enabled) {
			var emission = origin.emission;
			emission.enabled = enabled;
		}

		#endregion
		#region Render texture

		public static void ClearColor(this RenderTexture tex) {
			if (!SystemInfo.SupportsRenderTextureFormat(tex.format))
				return;

			Graphics.SetRenderTarget(tex);
			GL.Clear(false, true, Color.clear);
		}

		public static void ClearColor(params RenderTexture[] renderTextures) {
			if (renderTextures.Length == 0)
				return;

			for (int i = 0; i < renderTextures.Length; i++) {
				if (renderTextures[i] == null || !SystemInfo.SupportsRenderTextureFormat(renderTextures[i].format))
					continue;

				Graphics.SetRenderTarget(renderTextures[i]);
				GL.Clear(false, true, Color.clear);
			}
		}

		#endregion
		#region Rigidbody

		/// <summary>
		/// Toggles the frozen state of a Rigidbody2D.
		/// </summary>
		/// <param name="origin">The Rigidbody2D to freeze or unfreeze.</param>
		/// <param name="isFreezed">Pass true to freeze the Rigidbody2D, false to unfreeze it.</param>
		public static void ToggleFreezed(this Rigidbody2D origin, bool isFreezed) {
			if (origin.isKinematic = isFreezed) {
				origin.velocity = Vector2.zero;
				origin.angularVelocity = 0;
			}
		}

		/// <summary>
		/// Toggles the frozen state of a Rigidbody.
		/// </summary>
		/// <param name="origin">The Rigidbody to freeze or unfreeze.</param>
		/// <param name="isFreezed">Pass true to freeze the Rigidbody, false to unfreeze it.</param>
		public static void ToggleFreezed(this Rigidbody origin, bool isFreezed) {
			if (origin.isKinematic = isFreezed) {
				origin.velocity = Vector2.zero;
				origin.angularVelocity = Vector3.zero;
			}
		}

		#endregion
	}
}