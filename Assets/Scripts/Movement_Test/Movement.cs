using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private Rigidbody rbody; 
	[SerializeField][Range(0,1000)]
	public float Velocity;  
	[SerializeField][Range(0,1000)]
	public float TurningVelocity; 
	[SerializeField][Range(0,100)]
	public float TiltVelocity; 
	[SerializeField][Range(0,10)]
	public float Multiplier; 
	private Vector2 velocity; 
	private float MultiplierX, MultiplierY; 
	private Transform Graphics; 
	private bool RotPositive, Rotate, Tilt, TiltPositive; 

	void Awake(){
		RotPositive = false; 
		MultiplierX = MultiplierY = 1; 
		Graphics = this.transform.GetChild (0); 
		rbody = this.GetComponent<Rigidbody> (); 
	}

	void Update(){
		if (Input.GetAxis ("Horizontal") != 0 && MultiplierX<(Multiplier * 1.4142f)) {
			MultiplierX += Time.deltaTime; 
		} else {
			MultiplierX = 1; 
		}
		if (Input.GetAxis ("Vertical") != 0 && MultiplierY<(Multiplier * 1.4142f)) {
			MultiplierY += Time.deltaTime; 
		} else {
			MultiplierY = 1; 
		}
		if (Input.GetAxis ("Horizontal") > 0 ) {
			RotPositive = false; 
			Rotate = true; 
		}  else if (Input.GetAxis ("Horizontal") < 0 ) {
			RotPositive = true; 
				Rotate = true; 
		}  else {
			Rotate = false; 
		}
		if (Input.GetAxis ("Vertical") > 0 ) {
			TiltPositive = false; 
			Tilt = true; 
		}  else if (Input.GetAxis ("Vertical") < 0 ) {
			TiltPositive = true; 
			Tilt = true; 
		}  else {
			Tilt = false; 
		}

		velocity = new Vector2 (Input.GetAxis("Horizontal") * Velocity * 1.4142f * MultiplierX, Input.GetAxis ("Vertical") * Velocity * 1.4142f * MultiplierY); 
	}

	void FixedUpdate(){
		rbody.velocity = velocity * Time.fixedDeltaTime; 
		if (Rotate && RotPositive ) {
			if (Graphics.localRotation.z < 0.5f) {
				Graphics.RotateAround (Graphics.position, Vector3.forward, TurningVelocity * Time.fixedDeltaTime);
			} else {
				Mathf.Clamp (Graphics.localRotation.z, -0.5f, 0.5f); 
			}
		} else if (Rotate && !RotPositive) {
			if (Graphics.localRotation.z > -0.5f) {
				Graphics.RotateAround (Graphics.position, Vector3.forward, -TurningVelocity * Time.fixedDeltaTime); 
			} else {
				Mathf.Clamp (Graphics.localRotation.z, -0.5f, 0.5f); 
			}
		} else {
			Graphics.rotation = Quaternion.Lerp (Graphics.rotation, Quaternion.identity, 3 * Time.fixedDeltaTime); 
		}
		if (Tilt && TiltPositive) {
			Graphics.RotateAround (Graphics.position, Vector3.right, TiltVelocity * Time.fixedDeltaTime);
		} else if (Tilt && !TiltPositive) {
			Graphics.RotateAround (Graphics.position, Vector3.right, -TiltVelocity * Time.fixedDeltaTime); 
		}
	}



}
