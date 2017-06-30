using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evasion : MonoBehaviour {

	private Coroutine _current; 
	private Vector3 left, right, original; 
	private bool goLeft; 
	[SerializeField][Range(0,10)]
	public float Speed; 


	void Awake(){
		goLeft = true; 
	}

	
	public void StartEvading(){
		original = this.transform.position; 
		left = original - Vector3.right * 2; 
		right = original + Vector3.right * 2; 
		_current = null; 
		_current = StartCoroutine (evading ()); 
	}
	public void StopEvading(){
		if (_current != null) {
			StopCoroutine (_current); 
		}
	}

	IEnumerator evading(){
		Vector3 target = left; 
		float percentage = 0; 
		while (true) {
			if (goLeft) {
				this.transform.position = Vector3.Slerp (original, target,  percentage); 
				if (this.transform.position == left) {
					original = left; 
					target = right; 
					goLeft = false; 
					percentage = 0; 
				}
			} else {
				this.transform.position = Vector3.Slerp (original, target,percentage); 
				if (this.transform.position == right) {
					original = right; 
					target = left; 
					goLeft = true; 
					percentage = 0; 
				}
			}
			percentage += Time.fixedDeltaTime * Speed; 

			
			yield return new WaitForSeconds (Time.fixedDeltaTime); 
		}
	}

}
