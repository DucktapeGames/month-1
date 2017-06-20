using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair1: MonoBehaviour {

	private Transform player; 
	public float depth; 
	private Vector3 direction; 
	private Vector3 screenPos; 

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player").transform; 
	}

	void Update(){
		screenPos = Camera.main.ScreenPointToRay (Input.mousePosition).GetPoint (depth);
		direction = screenPos - player.position; 
	}

	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = player.position + direction.normalized * depth;
	}
}
