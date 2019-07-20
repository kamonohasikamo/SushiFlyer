using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitButton : MonoBehaviour {
	public void ExitButtonTap() {
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_STANDALONE
			UnityEngine.Application.Quit();
		#endif
	}
}
