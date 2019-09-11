using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//===========================================================
// Game全般を処理するクラス
//===========================================================
public class GameController : MonoBehaviour {
	// Gameの状態を管理する列挙型
	enum gameStateInfo {
		isReady,
		isPlay,
		isGameOver
	}

	gameStateInfo gameState;

	public PlayerController player;
	public GameObject blocks;

	public static int gameScore;

	public static bool isGameStart;

	public float totalTime;

	void Start() {
		isGameStart = false;
		Ready();
	}

	void Update() {
		switch (gameState) {
			case gameStateInfo.isReady:
				gameScore = 0;
				break;
			case gameStateInfo.isPlay:
				totalTime += Time.deltaTime;
				gameScore = (int)totalTime;
				break;
			case gameStateInfo.isGameOver:
				
				break;
		}

	}

	void LateUpdate() {
		switch(gameState) {
			case gameStateInfo.isReady:
				if (Input.GetButtonDown("Fire1")) {
					isGameStart = true;
					gameStart();
				}
				break;
			case gameStateInfo.isPlay:
				if (player.getIsGameOver()) {
					gameOver();
				}
				break;
			case gameStateInfo.isGameOver:
				// if (Input.GetButtonDown("Fire1")) {
				// 	Reload();
				// }
				break;
		}
	}

	void Ready() {
		gameState = gameStateInfo.isReady;

		// 全てのオブジェクトを無効化
		player.setGravity(false);
		blocks.SetActive(false);
		gameScore = 0;
	}

	void gameStart() {
		gameState = gameStateInfo.isPlay;

		player.setGravity(true);
		blocks.SetActive(true);

		// Startの一回だけおまけ
		player.upVector();
	}

	void gameOver() {
		gameState = gameStateInfo.isGameOver;

		// 全てのオブジェクトを検索
		ScrollBackground[] scrollObjects = GameObject.FindObjectsOfType<ScrollBackground>();

		// 全てのオブジェクト停止
		foreach (ScrollBackground so in scrollObjects) {
			so.enabled = false;
		}
		StartCoroutine("toResultSceneCoroutine");
	}

	private IEnumerator toResultSceneCoroutine() {
		yield return new WaitForSeconds (1.0f);
		SceneManager.LoadScene("GameResult");
	}

	void Reload() {
		// 現在のシーンを再読み込み
		isGameStart = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public static bool getIsGameStart() {
		return isGameStart;
	}

	public static int getGameScore() {
		return gameScore;
	}

	public static void setGameScore(int score) {
		gameScore = score;
	}

}
