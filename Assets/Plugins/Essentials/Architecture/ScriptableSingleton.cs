using UnityEngine;

namespace Essentials {
	public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject {

		private readonly static string Path = "Assets/Resources/{0}.asset";

		private static T _instance;

		public static T Instance {
			get {
				if (_instance == null) {
					var typeName = typeof(T).Name;
					_instance = Resources.Load<T>(typeName);

					if (_instance == null) {
						_instance = CreateInstance<T>();
						var path = string.Format(Path, typeName);

#if UNITY_EDITOR
						UnityEditor.AssetDatabase.CreateAsset(_instance, path);
						UnityEditor.AssetDatabase.SaveAssets();

						Debug.LogWarning($"Asset {path} don't exists. Created default instance.");

#else
						Debug.LogWarning($"Asset {path} don't exists.");
#endif
					}
				}
				return _instance;
			}
		}
	}
}