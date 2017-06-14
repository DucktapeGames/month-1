using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	private Pool mypool; 
	private Transform player; 
	private Bullet myBullet; 

	// Use this for initialization
	void Start () {
		mypool = GameObject.FindGameObjectWithTag ("Pool").GetComponent<Pool> (); 
		player = GameObject.FindGameObjectWithTag ("Player").transform; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			myBullet = mypool.AvailableBullet; 
			myBullet.Spawn (this.transform.position, player.position); 
			myBullet.Fire (); 
		}
	}
}
