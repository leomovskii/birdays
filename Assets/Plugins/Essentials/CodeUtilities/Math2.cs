using UnityEngine;

namespace Essentials {
	public static class Math2 {
		/// <summary>
		/// Remaps a value from one range to another.
		/// </summary>
		/// <param name="value">The value to remap.</param>
		/// <param name="oldRangeA">The minimum of the old range.</param>
		/// <param name="oldRangeB">The maximum of the old range.</param>
		/// <param name="newRangeA">The minimum of the new range.</param>
		/// <param name="newRangeB">The maximum of the new range.</param>
		/// <returns>The remapped value.</returns>
		public static float LinearRemap(float value, float oldRangeA, float oldRangeB, float newRangeA, float newRangeB) {
			var oldMin = Mathf.Min(oldRangeA, oldRangeB);
			var oldMax = Mathf.Max(oldRangeA, oldRangeB);

			var newMin = Mathf.Min(newRangeA, newRangeB);
			var newMax = Mathf.Max(newRangeA, newRangeB);

			return (value - oldMin) / (oldMax - oldMin) * (newMax - newMin) + newMin;
		}

		/// <summary>
		/// Applies Hermite interpolation between two values.
		/// </summary>
		/// <param name="start">The start value.</param>
		/// <param name="end">The end value.</param>
		/// <param name="value">Interpolation factor (0 to 1).</param>
		/// <param name="smoothness">The smoothness factor (between 0 and 1).</param>
		/// <returns>The interpolated value.</returns>
		public static float Hermite(float start, float end, float value, float smoothness = 0.5f) {
			if (smoothness < 0f || smoothness > 1f) {
				Debug.LogWarning("Hermite smoothness value should be between 0 and 1.");
				smoothness = Mathf.Clamp(smoothness, 0f, 1f);
			}
			return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
		}

		/// <summary>
		/// Applies sine-based interpolation between two values.
		/// </summary>
		/// <param name="start">The start value.</param>
		/// <param name="end">The end value.</param>
		/// <param name="value">Interpolation factor (0 to 1).</param>
		/// <param name="scale">Sine scale factor (default is 0.5).</param>
		/// <returns>The interpolated value.</returns>
		public static float Sinerp(float start, float end, float value, float scale = 0.5f) {
			if (scale <= 0f) {
				Debug.LogWarning("Sinerp scale should be greater than 0.");
				scale = 0.5f;
			}
			return Mathf.Lerp(start, end, Mathf.Sin(value * Mathf.PI * scale));
		}

		/// <summary>
		/// Applies smooth sine-based interpolation between two values.
		/// </summary>
		/// <param name="start">The start value.</param>
		/// <param name="end">The end value.</param>
		/// <param name="value">Interpolation factor (0 to 1).</param>
		/// <param name="offset">Sine offset (default is 0.5).</param>
		/// <returns>The interpolated value.</returns>
		public static float SmoothSin(float start, float end, float value, float offset = 0.5f) {
			if (offset < 0f || offset > 1f) {
				Debug.LogWarning("SmoothSin offset value should be between 0 and 1.");
				offset = Mathf.Clamp(offset, 0f, 1f);
			}
			return Mathf.Lerp(start, end, Mathf.Sin(value * 2 * Mathf.PI + Mathf.PI * offset));
		}

		/// <summary>
		/// Applies cosine-based interpolation between two values.
		/// </summary>
		/// <param name="start">The start value.</param>
		/// <param name="end">The end value.</param>
		/// <param name="value">Interpolation factor (0 to 1).</param>
		/// <param name="scale">Cosine scale factor (default is 0.5).</param>
		/// <returns>The interpolated value.</returns>
		public static float Coserp(float start, float end, float value, float scale = 0.5f) {
			if (scale <= 0f) {
				Debug.LogWarning("Coserp scale should be greater than 0.");
				scale = 0.5f;
			}
			return Mathf.Lerp(start, end, 1.0f - Mathf.Cos(value * Mathf.PI * scale));
		}

		/// <summary>
		/// Applies a complex interpolation function with adjustable factors.
		/// </summary>
		/// <param name="start">The start value.</param>
		/// <param name="end">The end value.</param>
		/// <param name="value">Interpolation factor (0 to 1).</param>
		/// <param name="sinFactor">Sine factor (default is 0.2).</param>
		/// <param name="powFactor">Power factor (default is 2.2).</param>
		/// <param name="extraFactor">Extra factor (default is 1.2).</param>
		/// <returns>The interpolated value.</returns>
		public static float Berp(float start, float end, float value, float sinFactor = 0.2f, float powFactor = 2.2f, float extraFactor = 1.2f) {
			if (sinFactor < 0f || powFactor < 0f || extraFactor < 0f) {
				Debug.LogWarning("Berp factors should be non-negative.");
				sinFactor = Mathf.Max(sinFactor, 0f);
				powFactor = Mathf.Max(powFactor, 0f);
				extraFactor = Mathf.Max(extraFactor, 0f);
			}
			value = Mathf.Clamp01(value);
			value = (Mathf.Sin(value * Mathf.PI * (sinFactor + 2.5f * value * value * value)) * Mathf.Pow(1f - value, powFactor) + value) * (1f + extraFactor * (1f - value));
			return start + (end - start) * value;
		}

		/// <summary>
		/// Applies a smooth step interpolation function.
		/// </summary>
		/// <param name="x">The input value to interpolate.</param>
		/// <param name="min">The minimum bound of the input range.</param>
		/// <param name="max">The maximum bound of the input range.</param>
		/// <returns>The smoothed value.</returns>
		public static float SmoothStep(float x, float min, float max) {
			if (min >= max) {
				Debug.LogWarning("SmoothStep min value should be less than max value.");
				return Mathf.Clamp01(x);
			}
			x = Mathf.Clamp(x, min, max);
			float v1 = (x - min) / (max - min);
			float v2 = v1;
			return -2 * v1 * v1 * v1 + 3 * v2 * v2;
		}

		/// <summary>
		/// Applies a bounce function to the input value.
		/// </summary>
		/// <param name="x">The input value to apply the bounce effect.</param>
		/// <param name="frequency">The frequency of the bounce (default is 6.28).</param>
		/// <param name="damping">The damping factor (default is 1).</param>
		/// <returns>The bouncy value.</returns>
		public static float Bounce(float x, float frequency = 6.28f, float damping = 1f) {
			if (frequency <= 0f || damping < 0f) {
				Debug.LogWarning("Bounce frequency should be greater than 0 and damping should be non-negative.");
				frequency = 6.28f;
				damping = 1f;
			}
			return Mathf.Abs(Mathf.Sin(frequency * (x + 1f) * (x + 1f)) * (1f - x) * damping);
		}

		/// <summary>
		/// Applies circular interpolation to handle wraparound from 0 to 360 degrees.
		/// </summary>
		/// <param name="start">The start value.</param>
		/// <param name="end">The end value.</param>
		/// <param name="value">Interpolation factor (0 to 1).</param>
		/// <param name="min">The minimum angle (default is 0).</param>
		/// <param name="max">The maximum angle (default is 360).</param>
		/// <returns>The interpolated angle.</returns>
		public static float Clerp(float start, float end, float value, float min = 0f, float max = 360f) {
			if (min >= max) {
				Debug.LogWarning("Clerp min value should be less than max value.");
				return Mathf.Lerp(start, end, value);
			}
			float half = Mathf.Abs((max - min) / 2f);
			return end - start < -half ? start + (max - start + end) * value
				: end - start > half ? start - (max - end + start) * value : start + (end - start) * value;
		}

		/// <summary>
		/// Applies dampening interpolation towards a target value.
		/// </summary>
		/// <param name="source">The current value.</param>
		/// <param name="target">The target value.</param>
		/// <param name="smoothing">The smoothing factor (between 0 and 1).</param>
		/// <param name="dt">The time delta.</param>
		/// <param name="snapEpsilon">The epsilon value for snapping to the target (default is 0.01).</param>
		/// <returns>The dampened value.</returns>
		public static float Damp(float source, float target, float smoothing, float dt, float snapEpsilon = 0.01f) {
			if (smoothing < 0f || smoothing > 1f) {
				Debug.LogWarning("Damp smoothing value should be between 0 and 1.");
				smoothing = Mathf.Clamp01(smoothing);
			}
			float value = Mathf.Lerp(source, target, 1 - Mathf.Pow(smoothing, dt));
			return Mathf.Abs(value - target) < snapEpsilon ? target : value;
		}
	}
}