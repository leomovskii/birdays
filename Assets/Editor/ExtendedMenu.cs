using UnityEditor.SceneManagement;
using UnityEditor;
using System.Reflection;
using UnityEditor.Experimental.SceneManagement;

public static class ExtendedMenu {

	[MenuItem("Edit/Exit Prefab Mode %w")]
	private static void ExitPrefabMode() {
		PrefabStage prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
		if (prefabStage != null) {
			MethodInfo savePrefabMethod = typeof(PrefabStage).GetMethod("SavePrefab", BindingFlags.NonPublic | BindingFlags.Instance);
			savePrefabMethod.Invoke(prefabStage, null);
			StageUtility.GoBackToPreviousStage();
		}
	}

	[MenuItem("Edit/Exit Prefab Mode %w", true)]
	private static bool ValidateExitPrefabMode() {
		return PrefabStageUtility.GetCurrentPrefabStage() != null;
	}
}