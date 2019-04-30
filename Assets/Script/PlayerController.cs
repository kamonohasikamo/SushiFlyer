using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rigidBody;

	public float maxHeightViewArea;
	public float playerUpVector;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeightViewArea) {
			upVector();
		}
	}

	public void upVector() {
		rigidBody.velocity = new Vector2(0.0f, playerUpVector);
	}

}
