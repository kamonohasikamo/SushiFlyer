using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameResultScoreTextController : MonoBehaviour {
	private GameObject gameResultScoreGameObject;
	private Text gameResultScoreText;

	void Start() {
		gameResultScoreText = this.gameObject.GetComponent<Text>();
		gameResultScoreText.text = "Score " + GameController.getGameScore().ToString("D5");
	}
}

