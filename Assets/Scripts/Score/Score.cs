using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public static int score;
	void Start () {
		score = 0;
		PublicScore.SCORE = score;
		UpdateScore();
	}
	
	public void AddScore(int value) {
		score += value;
		PublicScore.SCORE = score;
		UpdateScore();
	}

	void UpdateScore() {
		scoreText.text = "" + score;
	}
}
