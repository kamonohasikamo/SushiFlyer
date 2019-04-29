using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//======================================================================
// 背景画像をスクロールさせるのを扱うクラス
//======================================================================
public class ScrollBackground : MonoBehaviour {
	public float scrollSpeed = 1.0f;
	public float scrollStartPoint;
	public float scrollEndPoint;

	void Update() {
		// 毎フレームごとに、位置座標をずらす -> 背景がスクロールする
		transform.Translate(-1 * scrollSpeed * Time.deltaTime, 0, 0);

		if (transform.position.x <= scrollEndPoint) {
			endPositionBackGround();
		}
	}

	private void endPositionBackGround() {
		transform.Translate(-1 * (scrollEndPoint - scrollStartPoint), 0, 0);

		SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
	}

}
