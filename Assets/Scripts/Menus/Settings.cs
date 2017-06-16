using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

	public AudioMixer MasterMixer;

	public float Volume {
		set {
			MasterMixer.SetFloat("MusicVolume", Mathf.Clamp(value, -80, 20));
		}

		get {
			float val;
			MasterMixer.GetFloat ("MusicVolume", out val);
			return val;
		}
	}
}
