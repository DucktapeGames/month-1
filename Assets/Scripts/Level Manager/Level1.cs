using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {

	[SerializeField] 
	public SpawnPoint TopLeft, BottomLeft, TopMiddle, BottomMiddle, TopRight, BottomRight; 
	private Coroutine current; 

	void Start(){
		Cursor.visible = false; 
		StartSequence1 (); 
	}

	IEnumerator SpawnSequence1(){
		yield return new WaitForSeconds (2f);
		TopLeft.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		TopMiddle.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		TopRight.SpawnNewEnemy (); 
		while(!IsEveryoneDead()){
			yield return new WaitForSeconds (2f); 
		}
		StartSequence2 (); 
	}
	IEnumerator SpawnSequence2(){
		yield return new WaitForSeconds (2f);
		BottomLeft.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		BottomMiddle.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		BottomRight.SpawnNewEnemy (); 
		while(!IsEveryoneDead()){
			yield return new WaitForSeconds (2f); 
		}
		StartSequence3 ();
	}
	IEnumerator SpawnSequence3(){
		yield return new WaitForSeconds (2f);
		TopLeft.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		BottomMiddle.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		TopRight.SpawnNewEnemy (); 
	}


	bool IsEveryoneDead(){
		if (!TopLeft.IsEnemyAlive &&
		    !BottomLeft.IsEnemyAlive &&
		    !TopMiddle.IsEnemyAlive &&
		    !BottomMiddle.IsEnemyAlive &&
		    !TopRight.IsEnemyAlive &&
		    !BottomRight.IsEnemyAlive) {
			return true; 
		} else {
			return false; 
		}
	}

//________________________________ Lots of the same stuff _____________________________//

	void StartSequence1(){
		current = null; 
		current = StartCoroutine (SpawnSequence1());
	}
	void StopSequence1(){
		if (current != null) {
			StopCoroutine (current); 
		}
		current = null; 
	}
	void StartSequence2(){
		current = null; 
		current = StartCoroutine (SpawnSequence2());
	}
	void StopSequence2(){
		if (current != null) {
			StopCoroutine (current); 
		}
		current = null; 
	}
	void StartSequence3(){
		current = null; 
		current = StartCoroutine (SpawnSequence3());
	}
	void StopSequence3(){
		if (current != null) {
			StopCoroutine (current); 
		}
		current = null; 
	}
}
