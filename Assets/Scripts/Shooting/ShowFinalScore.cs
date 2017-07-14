using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFinalScore : MonoBehaviour {
	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + PublicScore.SCORE;
	}
}
