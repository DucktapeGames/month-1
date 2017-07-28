using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	private Transform player; 
	private Vector3 direction; 
	private Vector3 screenPos; 
	private Vector3 targetPos; 
	private float angle; 
	[SerializeField][Range(1,20)]
	public float depth; 
	public bool IsFirst; 

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("PlayerBody").transform; 
	}

	void Update(){
		screenPos = Camera.main.ScreenPointToRay (Input.mousePosition).GetPoint (25);
		direction = (screenPos - player.position).normalized; 
		targetPos = screenPos - (direction * depth); 
		transform.rotation = Quaternion.LookRotation (direction, Vector3.up); 
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = targetPos;  
	}
}
