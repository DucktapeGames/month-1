using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour {

	public Slider VolumeSlider;
	public Settings SettingsRef;

	// Use this for initialization
	void Start () {
		VolumeSlider.value = SettingsRef.Volume;
	}

	public void GoToMenu () {
		SceneManager.LoadScene(0);
	}
}
