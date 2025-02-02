# AbstractCollectableMonoBehaviour<T>
An abstract class for objects that should be collected into a list when they are activated, and removed from that list when they are deactivated. This is useful for managing groups of objects that should be available at any given time.

The generic parameter T is the type of the inheritor.
On activation, the object is added to a static list.
On deactivation, the object is removed from the list.
Use example: Creating objects, such as collectibles or enemies, that can be easily collected into a list and made available for manipulation.

``` csharp
public class MapItem : AbstractCollectableMonoBehaviour<MapItem> {

	public static List<MapItem> FindItemsNearby(Vector3 location, float radius) {
		var items = new List<MapItem>();

		_list.ForEach(e => {
			if (Vector3.Distance(e.transform.position, location) <= radius)
				items.Add(e);
		});

		return items;
	}
}
```

# ScriptableSingleton<T>
An abstract class for creating Singleton objects based on ScriptableObject. This class automatically creates a ScriptableObject instance if it does not exist and stores it in Resources.

The generic parameter T is the type of the inheritor.
Asset path: Assets/Resources/{TypeName}.asset.
Automatically creates and saves an instance in the editor if it is not found.
Use example: Use this class to create unique data objects, such as game configurations or global settings, that should be accessible from any part of the project.

``` csharp
public enum SoundType {
	ButtonClick,
	WindowSwitch,
	// etc
}

[System.Serializable]
public class SoundVariant {
	public SoundType Type;
	public AudioClip Clip;
}

public class SoundCatalog : ScriptableSingleton<SoundCatalog> {

	[SerializeField] private List<SoundVariant> _sounds;

	public bool TryFindSoundOfType(SoundType soundType, out SoundVariant variant, bool showNotFindError = true) {
		variant = _sounds.FirstOrDefault(e => e.Type == soundType);
		if (variant == null && showNotFindError)
			Debug.LogError($"SoundCatalog don't has info about {soundType} sound type.");
		return variant != null;
	}
}
```

# Singleton<T>
An abstract class for implementing the Singleton pattern in MonoBehaviour. Ensures that there is only one instance of the object in the scene.

The generic parameter T is the type of the inheritor.
Automatically finds the object in the scene or creates a new instance when accessed.
When creating a new instance, calls the virtual method OnAwakened() for additional initialization.
Example usage: Used for objects such as game managers, cameras, or input systems that should only exist in one instance during the game.

``` csharp
public class GameManager : Singleton<GameManager> {
	protected override void OnAwakened() {
		Debug.Log("GameManager is ready!");
	}
}
```
