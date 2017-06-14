using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {
	public DialogManager manager;
	public GameObject pressAlert;
	public bool triggerOnce;
	public bool pressToTrigger;
	public int dialogId;

	private bool triggered;
	private bool triggerStay;

	void Start() {
		triggered = false;
		pressAlert.SetActive(false);
	}

	void Update() {
		if(triggerStay) {
			if(pressToTrigger) {
				if(Input.GetButtonDown("Action")) {
					Trigger();
				}
			}
		}
	}

	void Trigger() {
		if(!triggerOnce || !triggered) {
			manager.StartDialog(dialogId);
			triggered = true;
			pressAlert.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			if(!pressToTrigger) {
				Trigger();
			} else {
				if(!triggerOnce || !triggered) {
					pressAlert.SetActive(true);
					triggerStay = true;
				}
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "Player") {
			if(pressToTrigger) {
				if(!triggerOnce || !triggered) {
					pressAlert.SetActive(false);
					triggerStay = false;
				}
			}
		}
	}
}
