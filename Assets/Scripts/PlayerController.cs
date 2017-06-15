using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float acceleration;
	public float rotationSpeed;
	private Rigidbody rb;
	private Quaternion originalRotation;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		rb = GetComponent<Rigidbody>();
		originalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var vert = Input.GetAxis("Vertical");
		var horiz = Input.GetAxis("Horizontal");
		var mouseX = Input.GetAxis("Mouse X");
		var mouseY = Input.GetAxis("Mouse Y");

		transform.Rotate(new Vector3(mouseY, horiz, -mouseX) * Time.deltaTime * rotationSpeed);
		//rb.AddTorque(new Vector3(mouseY, horiz, -mouseX) * rotationSpeed);
		rb.AddForce(transform.rotation * new Vector3(0, 0, vert) * acceleration);
	}
}
