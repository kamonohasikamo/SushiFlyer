using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreTextController : MonoBehaviour {
	public GameObject scoreTextGameObject;
	private Text scoreText;

	void Start() {
		scoreText = this.gameObject.GetComponent<Text>();
		scoreText.text = "Score:" + GameController.getGameScore().ToString("D5");
	}

	void Update() {
		scoreText.text = "Score:" + GameController.getGameScore().ToString("D5");
	}

}
