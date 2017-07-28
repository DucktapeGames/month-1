using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

public class Enemy : MonoBehaviour, IPoolable, IDamageable {

	private Vector3 _spawnPosition, _deSpawnPosition, _previousPosition; 
	private Coroutine _current, _shootingRoutine;  
	private Transform _target, _barrel; 
	private Bullet _bullet; 
	[SerializeField][Range(0,100)]
	public float FireRate;

	private int _totalHp;
	private int _hp;
	public int life;
	private Score scoreManager;
	private Animator anim; 


	void Start() {
		_deSpawnPosition = this.transform.position; 
		_barrel = this.transform.GetChild (2);
		_totalHp = life;
		_hp = 0;
		anim = this.gameObject.GetComponentInChildren<Animator> (); 
		anim.speed = 0; 
		// This allows enemies to modify score
		GameObject scoreManagerObject = GameObject.FindWithTag("ScoreManager");
		if (scoreManagerObject != null)
        {
        	scoreManager = scoreManagerObject.GetComponent<Score>();
        }
        if (scoreManager == null)
        {
            Debug.Log ("Cannot find 'Score' script or Object with tag 'ScoreManager'");
        }
	}

	public void Spawn(Vector3 position, Transform target) {
		_spawnPosition = position; 
		_hp = life; 
		this.transform.position = _spawnPosition; 
		_target = target; 
		anim.speed = 1; 
		this.transform.rotation = Quaternion.LookRotation (this.transform.position - _target.position);  
		StartShooting (); 

	}

	public void DeSpawn() {
		_target = null;  
		if (_bullet != null) {
			_bullet.DeSpawn ();
		}
		this.transform.position = _deSpawnPosition; 
		StopShooting ();
		anim.speed = 0; 

	}

	public void Shoot() {
		_bullet = Pool.Instance.AvailableBullet; 
		_bullet.Spawn (_barrel.position, _target); 
		_bullet.Fire (); 
	}

	void StartShooting() {
		_shootingRoutine = null; 
		_shootingRoutine = StartCoroutine (shooting ()); 
	}

	void StopShooting(){
		if (_shootingRoutine != null) {
			StopCoroutine (_shootingRoutine); 
		}
	} 
	IEnumerator shooting(){
		float randomeDisplacement = Random.Range (0, 3f); 
		yield return new WaitForSeconds (randomeDisplacement); 
		while (true) {
			Shoot (); 
			yield return new WaitForSeconds (FireRate * Time.fixedDeltaTime); 
		}
	}

	public bool IsEnemy() {
		return true;
	}

	public int TotalHp {
		get {
			return _totalHp;
		}
		set {
			_totalHp = value;
		}
	}

	public int Hp {
		get {
			return _hp;
		}
		set {
			_hp = value;
		}
	}

	public void Damage(int dmg) {
		_hp -= dmg;
		if(_hp <= 0) {
			Kill();
		}
	}

	public void Kill() {
		scoreManager.AddScore(10);
		DeSpawn();
	}
}
