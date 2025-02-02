using UnityEngine;

namespace Essentials {
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

		protected static T _instance;

		public static T Instance {
			get {
				if (_instance == null) {
					_instance = FindObjectOfType<T>();
					if (_instance is Singleton<T> instance)
						instance.OnAwakened();
				}
				return _instance;
			}
		}

		private void Awake() {
			if (_instance == null) {
				_instance = this as T;
				OnAwakened();

			} else if (_instance != this) {
				Destroy(gameObject);
			}
		}

		protected virtual void OnAwakened() { }

	}
}