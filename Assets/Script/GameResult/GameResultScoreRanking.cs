using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameResultScoreRanking : MonoBehaviour {
	[SerializeField] Text ranking;
	private int[] scoreSort = new int[6];

	void Start() {
		ranking.GetComponent<Text>().text = "";
		saveRanking();
		showRanking();
		// GameController.setGameScore(0);
	}

	void saveRanking() {
		PlayerPrefs.SetInt("5", GameController.getGameScore());
		PlayerPrefs.Save();
	}

	void showRanking() {
		for (int i = 0; i < 6; i++) {
			scoreSort[i] = PlayerPrefs.GetInt("" + i, 0);
		}
		for (int start = 1; start < scoreSort.Length; start++) {
			for (int end = scoreSort.Length - 1; end >= start; end--) {
				if (scoreSort[end - 1] <= scoreSort[end]) {
					scoreSort[end - 1] = scoreSort[end - 1] + scoreSort[end];
					scoreSort[end] = scoreSort[end - 1] - scoreSort[end];
					scoreSort[end - 1] = scoreSort[end - 1] - scoreSort[end];
				}
			}
		}

		bool nowScoreShowFlag = true;
		for (int i = 0; i < 5; i++) {
			if (nowScoreShowFlag && GameController.getGameScore() == scoreSort[i]) {
				ranking.GetComponent<Text>().text += "<color=red>" + (i + 1) + "	Score " + scoreSort[i].ToString("D5") + "</color>\n";
				PlayerPrefs.SetInt("" + i, scoreSort[i]);
				nowScoreShowFlag = false;
			} else {
				ranking.GetComponent<Text>().text += (i + 1) + "	Score  " + scoreSort[i].ToString("D5") + "\n";
				PlayerPrefs.SetInt("" + i, scoreSort[i]);
			}
		}
		PlayerPrefs.Save();
	}
}
