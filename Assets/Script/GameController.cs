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

	void Start() {
		Ready();
	}

	void LateUpdate() {
		switch(gameState) {
			case gameStateInfo.isReady:
				if (Input.GetButtonDown("Fire1")) {
					gameStart();
				}
				break;
			case gameStateInfo.isPlay:
				if (player.getIsGameOver()) {
					gameOver();
				}
				break;
			case gameStateInfo.isGameOver:
				if (Input.GetButtonDown("Fire1")) {
					Reload();
				}
				break;
		}
	}

	void Ready() {
		gameState = gameStateInfo.isReady;

		// 全てのオブジェクトを無効化
		player.setGravity(false);
		blocks.SetActive(false);
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
	}

	void Reload() {
		// 現在のシーンを再読み込み
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
