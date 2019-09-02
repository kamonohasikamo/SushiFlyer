using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ChangeSceneWindow {
	private static string[] sceneList = new string[] {
		"GameStart",	// 1
		"GameScene",	// 2
		"GameResult",	// 3
	};
	[MenuItem("Tools/PlayGame %p+")]
	public static void PlayGame() {
		try {
			// 実行中は停止
			if (EditorApplication.isPlaying == true) {
				EditorApplication.isPlaying = false;
				return;
			}
			// Titleへ移動後に実行
			if (OpenScene(1)) {
				EditorApplication.isPlaying = true;
			}
		} catch {
			Debug.Log("[Err]前のシーンから再生");
		}
	}

	private static bool OpenScene(int sceneIndex) {
		bool isSuccess = false;
		try {
			if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
				EditorSceneManager.OpenScene(
					"Assets/Scenes/" + sceneList[sceneIndex - 1] + ".unity");
				isSuccess = true;
			}
		} catch {
			Debug.Log("[Err]OpenScene >> " + sceneIndex.ToString());
		}
		return isSuccess;
	}
	[MenuItem("Tools/OpenScene/Title %F5")]
	public static void OpenScene1() { 
		OpenScene(1);
	}
	[MenuItem("Tools/OpenScene/GameScene %F6")]
	public static void OpenScene2() { 
		OpenScene(2); 
	}
	[MenuItem("Tools/OpenScene/Result %F7")]
	public static void OpenScene3() { 
		OpenScene(3); 
	}
}
