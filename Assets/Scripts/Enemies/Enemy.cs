﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

public class Enemy : MonoBehaviour, IPoolable {

	private Vector3 _spawnPosition, _deSpawnPosition, _previousPosition; 
	private Coroutine _current; 
	private Transform _target, _barrel; 
	private Bullet _bullet; 
	[SerializeField][Range(0,100)]
	public float FireRate;
	[SerializeField][Range(0,100)]
	public float Speed; 

	private Vector3[] Path; 
	private MeshRenderer _renderer; 

	void Start(){
		_deSpawnPosition = this.transform.position; 
		_barrel = this.transform.GetChild (2); 
		_renderer = this.gameObject.GetComponentInChildren<MeshRenderer> (); 
	}

	public void Spawn(Vector3 position, Transform target){
		_spawnPosition = position; 
		this.transform.position = _spawnPosition; 
		_target = target; 
		this.transform.rotation = Quaternion.LookRotation (_target.position - this.transform.position); 
	}

	public void DeSpawn(){
		_target = null;  
		if (_bullet != null) {
			_bullet.DeSpawn ();
		}
		this.transform.position = _deSpawnPosition; 
	}

	IEnumerator TraversePath(){
		_previousPosition = _spawnPosition; 
		int pathIndex = 0;  
		float time = 0; 
		float shootTime = FireRate; 
		while (pathIndex<Path.Length) {
			this.transform.position = Vector3.Slerp (_previousPosition,(_spawnPosition + Path [pathIndex]),time + (Speed * Time.fixedDeltaTime));
			time += (Speed* Time.fixedDeltaTime); 
			if (shootTime <= FireRate) {
				shootTime += Time.fixedDeltaTime; 
			} else {
				Shoot (); 
				shootTime = 0; 
			}
			if (this.transform.position == (_spawnPosition + Path [pathIndex])) {//when you reach the waypoint go to the next position
				pathIndex++; 
			}
			yield return new WaitForSeconds (Time.fixedDeltaTime); 
		}
	}

	public void Shoot(){
		_bullet = Pool.Instance.AvailableBullet; 
		_bullet.Spawn (_barrel.position, _target); 
		_bullet.Fire (); 
	}

	public void SetColor(Color color){
		if (_renderer == null) {
			_renderer = this.gameObject.GetComponentInChildren<MeshRenderer> (); 
		}
		_renderer.material.color = color; 
	}
}
