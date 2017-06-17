using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePoint : MonoBehaviour {

	public Transform RespawnPoint; 


	void OnTriggerEnter(Collider something){
		Debug.Log ("Hey"); 
		something.transform.position = new Vector3 (something.transform.position.x,something.transform.position.y, RespawnPoint.position.z); 
	}
}
