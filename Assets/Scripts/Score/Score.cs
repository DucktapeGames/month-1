using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public static int score;
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
