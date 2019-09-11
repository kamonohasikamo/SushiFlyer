using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButtonController : MonoBehaviour {
	public void OnClickReplay() {
		SceneManager.LoadScene("GameScene");
	}
	
	public void OnClickTitle() {
		SceneManager.LoadScene("GameStart");
	}
}
