﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	private Enemy _enemy; 
	private Transform _player; 
	public bool IsEnemyAlive{
		get{
			if (_enemy != null) {
				if (_enemy.life > 0) {
					return true; 
				} else {
					return false; 
				}
			} else {
				return false; 
			}
		}
	}

	void Awake(){
		_player = GameObject.FindGameObjectWithTag ("PlayerBody").transform;
		Pool.ready += GetPoolReferences; 
	}

	void GetPoolReferences(){
		_enemy = Pool.Instance.AvailableEnemy; 
	}
		
	public void SpawnNewEnemy(){
		_enemy.DeSpawn (); 
		_enemy.Spawn (this.transform.position, _player); 
		_enemy = Pool.Instance.AvailableEnemy; 
	}

}
