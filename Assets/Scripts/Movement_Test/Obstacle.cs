using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	private Rigidbody rbody; 

	void Awake(){
		rbody = this.gameObject.GetComponent<Rigidbody> (); 
	}

	void FixedUpdate(){
		rbody.velocity = -Vector3.forward * 1000 * Time.fixedDeltaTime; 
	}

}
