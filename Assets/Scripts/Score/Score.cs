using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public GUIText scoreText;
	private int score;
	void Start () {
		score = 0;
		UpdateScore();
	}
	
	public void AddScore(int value) {
		score += value;
		UpdateScore();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}
}
