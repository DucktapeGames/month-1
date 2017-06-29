using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling; 
public class Pool : MonoBehaviour {

	public delegate void PoolRequest();
	public static event PoolRequest ready; 

	public static Pool Instance;

	private Queue<Bullet> bullets;
	private Queue<Enemy> enemies;

	[SerializeField][Range(0,100)]
	public float BulletCount; 
	[SerializeField][Range(0,100)]
	public float EnemyCount; 

	public Enemy EnemyPrefab; 
	public Enemy AvailableEnemy{
		get{
			Enemy aux = enemies.Dequeue (); 
			enemies.Enqueue (aux); 
			return aux; 
		}
	}
	public Bullet BulletPrefab; 
	public Bullet AvailableBullet{
		get{
			Bullet aux = bullets.Dequeue (); 
			bullets.Enqueue (aux); 
			return aux;  
		}
	}

	void Awake(){
		Instance = this; 
		bullets = new Queue<Bullet> (); 
		enemies = new Queue<Enemy> (); 
		Bullet aux; 
		Enemy eAux; 
		for (int n = 1; n <= BulletCount; n++) {
			aux = Instantiate (BulletPrefab, this.transform.position + (n * this.transform.right), Quaternion.identity, this.transform); 
			bullets.Enqueue (aux);
		}
		for (int n = 1; n <= EnemyCount; n++) {
			eAux = Instantiate (EnemyPrefab, this.transform.position + (n * 2* -this.transform.forward), Quaternion.identity, this.transform);
			eAux.SetColor (new Color (Random.value, Random.value, Random.value)); 
			enemies.Enqueue (eAux); 
		}

	}
	void Start(){
		ready (); 
	}
}
