using UnityEngine;

namespace Essentials {
	public static class TextureExtensions {

		/// <summary>
		/// Creates a sprite from a Texture2D with a specified pivot.
		/// </summary>
		/// <param name="origin">The source texture.</param>
		/// <param name="pivot">The pivot point of the sprite. Default is (0.5, 0.5) for center.</param>
		/// <returns>A new sprite that is created from the texture.</returns>
		public static Sprite CreateSprite(this Texture2D origin, Vector2 pivot = default(Vector2)) {
			return Sprite.Create(origin, new Rect(0, 0, origin.width, origin.height), pivot);
		}

		/// <summary>
		/// Creates a sprite from a Texture2D and centers the pivot.
		/// </summary>
		/// <param name="origin">The source texture.</param>
		/// <returns>A new sprite that is created from the texture with the pivot centered.</returns>
		public static Sprite CreateSpriteAndCenter(this Texture2D origin) {
			return origin.CreateSprite(new Vector2(0.5f, 0.5f));
		}

		/// <summary>
		/// Crops a Texture2D by specified pixel insets from the edges.
		/// </summary>
		/// <param name="origin">The source texture.</param>
		/// <param name="left">Pixel inset from the left edge.</param>
		/// <param name="right">Pixel inset from the right edge.</param>
		/// <param name="top">Pixel inset from the top edge.</param>
		/// <param name="down">Pixel inset from the bottom edge.</param>
		/// <returns>A new texture that is cropped according to the insets.</returns>
		public static Texture2D Crop(this Texture2D origin, int left = 0, int right = 0, int top = 0, int down = 0) {
			int width = origin.width - (left + right);
			int height = origin.height - (top + down);
			var pixels = origin.GetPixels(left, down, width, height);

			var result = new Texture2D(width, height, TextureFormat.RGB24, false);
			result.SetPixels(pixels);
			result.Apply();

			return result;
		}

		/// <summary>
		/// Tints a Texture2D with a specified color.
		/// </summary>
		/// <param name="origin">The texture to tint.</param>
		/// <param name="color">The color to use for tinting.</param>
		/// <returns>A new texture that is tinted with the specified color.</returns>
		public static Texture2D Tint(this Texture2D origin, Color color) {
			var target = new Texture2D(origin.width, origin.height);
			for (int i = 0; i < target.width; i++)
				for (int j = 0; j < target.height; j++)
					target.SetPixel(i, j, color);

			target.Apply();
			return target;
		}

		/// <summary>
		/// Converts a Texture2D to grayscale.
		/// </summary>
		/// <param name="origin">The source texture.</param>
		/// <returns>A new texture that is a grayscale version of the source.</returns>
		public static Texture2D ToGrayscale(this Texture2D origin) {
			var texture = new Texture2D(origin.width, origin.height, origin.format, false);
			texture.SetPixels(origin.GetPixels());
			texture.Apply();

			var pixels = texture.GetPixels();

			for (int i = 0; i < pixels.Length; i++) {
				var pixel = pixels[i];
				float l = 0.2126f * pixel.r + 0.7152f * pixel.g + 0.0722f * pixel.b;
				pixels[i] = new Color(l, l, l, pixel.a);
			}

			texture.SetPixels(pixels);
			texture.Apply();

			return texture;
		}
	}
}
