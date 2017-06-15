﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	private Enemy _enemy; 
	private Transform _player; 

	void Awake(){
		_player = GameObject.FindGameObjectWithTag ("Player").transform;
		Pool.ready += GetPoolReferences; 
	}

	void GetPoolReferences(){
		_enemy = Pool.Instance.AvailableEnemy; 
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			_enemy.Spawn (this.transform.position, _player); 
			_enemy.Shoot (); 
		} else if (Input.GetKeyDown (KeyCode.Tab)) {
			_enemy.DeSpawn (); 
			_enemy = Pool.Instance.AvailableEnemy; 
		}
	}

}