using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//=====================================================
// お寿司を管理するクラス
//=====================================================
public class PlayerController : MonoBehaviour {
	Rigidbody2D rigidBody;
	public float maxHeightViewArea;
	public float playerUpVector;
	private bool isGameOver;

	public bool getIsGameOver() {
		return isGameOver;
	}

	public void setIsGameOver(bool setFlagIsGameOver) {
		isGameOver = setFlagIsGameOver;
	}

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeightViewArea) {
			upVector();
		}
	}

	public void upVector() {
		// ゲームオーバー判定
		if (getIsGameOver()) {
			return;
		}
		// 重力ないときは動作しない
		if (rigidBody.isKinematic) {
			return;
		}
		rigidBody.velocity = new Vector2(0.0f, playerUpVector);
	}

	void OnCollisionEnter2D(Collision2D collision2d) {
		if (isGameOver) {
			return;
		}
		// ぶつかった判定
		setIsGameOver(true);
	}
	public void setGravity(bool isGravity) {
		// 入力とは逆の判定を入れる
		rigidBody.isKinematic = !isGravity;
	}
}
