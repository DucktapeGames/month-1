using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private Rigidbody rbody; 
	[SerializeField][Range(1,30)]
	public float Slowness;  
	[SerializeField][Range(0,1000)]
	public float TurningVelocity; 
	[SerializeField][Range(0,100)]
	public float TiltVelocity; 
	[SerializeField][Range(0,10)]
	public float Multiplier; 
	//private Vector2 velocity; 
	private Transform Graphics; 
	private bool RotPositive, Rotate, Tilt, TiltPositive;
	private Vector3 position; 

	void Awake(){
		RotPositive = false; 
		Graphics = this.transform.GetChild (0); 
		rbody = this.GetComponent<Rigidbody> (); 
		position = this.transform.position; 
	}

	void Update(){ 
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
		position = new Vector3 (7.4f * (Input.GetAxis ("Horizontal")/Slowness), (10.5f * (Input.GetAxis ("Vertical")/Slowness)), 0) + this.transform.position;
		position.x = Mathf.Clamp (position.x, -7.4f, 7.4f); 
		position.y = Mathf.Clamp (position.y, 2, 9.5f); 

	}

	void FixedUpdate() {
		this.transform.position = position; 
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
