using UnityEngine;

namespace Essentials {
	public class DontDestroy : MonoBehaviour {
		private void Awake() {
			DontDestroyOnLoad(gameObject);
		}
	}
}