using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinTextController : MonoBehaviour
{
	public GameObject coinTextGameObject;
	private Text coinText;

	void Start() {
		coinText = this.gameObject.GetComponent<Text>();
		coinText.text = "×" + GameController.getGameScore().ToString("D3");
	}

	void Update() {
		coinText.text = "×" + GameController.getGameScore().ToString("D3");
	}
}