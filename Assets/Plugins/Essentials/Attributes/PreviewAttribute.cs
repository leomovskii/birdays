namespace Essentials {
	public class PreviewAttribute : UnityEngine.PropertyAttribute {
		public float Size { get; }
		public PreviewAttribute(float size = 64f) {
			Size = size;
		}
	}
}