using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

public class Bullet : MonoBehaviour, IPoolable{
	private Vector3 _spawnPosition, _target, _deSpawnPosition;
	private bool _enemyBullet = false;
	private Renderer _renderer;
	private Coroutine _current; 
	[SerializeField][Range(0,100)]
	public float Speed; 
	[SerializeField][Range(0,10)]
	public float LifeTime;
	// Damage that is going to be done to player when hit
	public int damageToPlayer;
	// Damage that is going to be done to player when hit
	public int damageToEnemy;

	void Start() {
		_deSpawnPosition = this.transform.position;
		//if mayor event happens despawn. you need an event or delegate. 
	}
		
	public void Spawn(Vector3 position, Transform target) {
		_enemyBullet = true;
		SetColor(Color.red);
		_spawnPosition = position; 
		this.transform.position = _spawnPosition; 
		_target = target.position; 
		this.transform.rotation = Quaternion.LookRotation (_target - this.transform.position); 
	}

	public void Spawn2(Vector3 position, Vector3 target) {
		_enemyBullet = false;
		SetColor(Color.green);
		_spawnPosition = position; 
		this.transform.position = _spawnPosition; 
		_target = target; 
		this.transform.rotation = Quaternion.LookRotation (_target - this.transform.position); 
	}

	public void DeSpawn() {
		PauseFire(); 
		_target = Vector3.zero;  
		this.transform.position = _deSpawnPosition; 
	}

	public void Fire() {
		_current = null; 
		_current = StartCoroutine (ShootTowardsPlayer ()); 
	}
	public void PauseFire() {
		if (_current != null) {
			StopCoroutine (_current); 
		}
	}

	IEnumerator ShootTowardsPlayer(){
		float Distance = 0; 
		float LivedTime = 0; 
		while(LivedTime <= LifeTime && this.transform.position != _target){
			this.transform.position = Vector3.MoveTowards (_spawnPosition, _target,Distance + (Speed * Time.fixedDeltaTime )); 
			Distance += (Speed * Time.fixedDeltaTime); 
			LivedTime += Time.fixedDeltaTime; 
			yield return new WaitForSeconds(Time.fixedDeltaTime); 
		}
		DeSpawn (); 
		yield return null;
	}

	public void SetColor(Color color) {
		if (_renderer == null) {
			_renderer = GetComponentInChildren<Renderer>(); 
		}
		_renderer.material.SetColor("_Color", color);
	}

	void OnTriggerEnter(Collider something) {
		if(something.tag == "PlayerBody") {
			something.gameObject.GetComponentInParent<Health>().Damage(damageToPlayer);
			DeSpawn();
		}
		if(something.tag == "Enemy" && !_enemyBullet) {
			something.gameObject.GetComponentInParent<Enemy>().Damage(damageToEnemy);
			DeSpawn();
		}
	}
}