using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IDamageable {

	private int _totalHp;
	private int _hp;
	public Text lifeText;

	public int life;

	void Start () {
		_totalHp = life;
		_hp = life;
		UpdateLife();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsEnemy() {
		return false;
	}

	public void Damage(int dmg) {
		_hp -= dmg;
		if(_hp <= 0) {
			Kill();
		}
		UpdateLife();
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

	public void Kill() {
		SceneManager.LoadScene(5);
	}

	public void UpdateLife() {
		lifeText.text = "HP " + Hp + "/" + TotalHp;
	}
}
