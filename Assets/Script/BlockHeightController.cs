using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//===========================================
// ブロックの幅の位置調整クラス
//===========================================
public class BlockHeightController : MonoBehaviour {
	public float minBlockHeight;
	public float maxBlockHeight;
	public GameObject showBlocks;

	void Start() {
		changeBlockHeight();
	}

	// 毎フレームランダムでMax～Minの範囲で高さを生成
	// 壁を出現させるときにさまざまな高さになるはず
	void changeBlockHeight() {
		float blockHeight = Random.Range(minBlockHeight, maxBlockHeight);
		showBlocks.transform.localPosition = new Vector3(0.0f, blockHeight, 0.0f);
	}

	// Executed if a message is received from the Scroll Object.
	void OnScrollEnd() {
		changeBlockHeight();
	}
}
