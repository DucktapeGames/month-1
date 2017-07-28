using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {

	[SerializeField] 
	public SpawnPoint TopLeft, BottomLeft, TopMiddle, BottomMiddle, TopRight, BottomRight; 
	private Coroutine current; 

	void Start(){
		StartSequence1 (); 
		Cursor.visible = false; 
	}

	void Update(){
		if (!TopLeft.IsEnemyAlive && !TopMiddle.IsEnemyAlive && !TopRight.IsEnemyAlive) {
			StartSequence2 (); 
		}
	}

	IEnumerator SpawnSequence1(){
		yield return new WaitForSeconds (2f);
		TopLeft.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		TopMiddle.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		TopRight.SpawnNewEnemy (); 
	}
	IEnumerator SpawnSequence2(){
		yield return new WaitForSeconds (2f);
		BottomLeft.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		BottomLeft.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		BottomRight.SpawnNewEnemy (); 
	}
	IEnumerator SpawnSequence3(){
		yield return new WaitForSeconds (2f);
		TopLeft.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		BottomLeft.SpawnNewEnemy (); 
		yield return new WaitForSeconds (2f);
		TopRight.SpawnNewEnemy (); 
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
}
