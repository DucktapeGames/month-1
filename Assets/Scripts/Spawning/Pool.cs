using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {
	private Queue<Bullet> bullets;

	[SerializeField][Range(1,100)]
	public float BulletCount; 
	public Bullet BulletPrefab; 
	public Bullet AvailableBullet{
		get{
			Bullet aux = bullets.Dequeue (); 
			bullets.Enqueue (aux); 
			return aux; 
		}
	}

	void Awake(){
		bullets = new Queue<Bullet> (); 
		Bullet aux; 
		for (int n = 1; n <=BulletCount; n++) {
			aux = Instantiate (BulletPrefab, this.transform.position + (n * this.transform.right), Quaternion.identity, this.transform); 
			bullets.Enqueue (aux); 
		}
	}
		


}
