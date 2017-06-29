using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	private Transform player; 
	public float ScreenDepth; 
	public float Depth; 
	private Vector3 direction; 
	private Vector3 screenPos; 
	private Vector3 targetPos; 

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player").transform; 
	}

	void Update(){
		screenPos = Camera.main.ScreenPointToRay (Input.mousePosition).GetPoint (ScreenDepth);
		direction = screenPos - player.position; 
		targetPos = player.position + direction.normalized * Depth; 
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = targetPos;  
	}
}
