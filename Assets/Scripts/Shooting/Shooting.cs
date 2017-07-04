using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

public class Shooting : MonoBehaviour {
	private Transform _barrel;
	private Vector3 _target;
	private Vector3 screenPos, direction, targetPos;
	public int ScreenDepth, Depth;
	private Bullet _bullet; 
	[SerializeField][Range(0,100)]
	public float FireRate;
	[SerializeField][Range(0,100)]
	public float Speed;

	// Use this for initialization
	void Start () {
		_barrel = this.transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () {
		screenPos = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(ScreenDepth);
		direction = screenPos - transform.position; 
		targetPos = transform.position + direction.normalized * Depth;
		_target = targetPos;

		if(Input.GetMouseButtonDown(0)) {
			Shoot();
		}
	}

	public void Shoot() {
		_bullet = Pool.Instance.AvailableBullet; 
		_bullet.Spawn2(_barrel.position, _target); 
		_bullet.Fire();
	}
}
