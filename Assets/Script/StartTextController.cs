using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//===========================================================
// GameStart時の
//「Tap To Start」の文字の点滅などの処理を行うクラス
//===========================================================
public class StartTextController : MonoBehaviour {
	
	public GameObject startTextGameObject;
	public float gameStartTextBlinkSpeed;
	private Text gameStartText;
	private float time;
	void Start() {
		gameStartText = this.gameObject.GetComponent<Text>();
		gameStartText.text = "Tap to Start";
	}

	void Update() {
		if (!GameController.getIsGameStart()) {
			gameStartText.color = getAlphaColor(gameStartText.color);
		} else {
			startTextGameObject.SetActive(false);
		}
	}

	Color getAlphaColor(Color color) {
		time += Time.deltaTime * 5.0f * gameStartTextBlinkSpeed;
		color.a = Mathf.Sin(time) * 0.5f + 0.5f;

		return color;
	}

}
