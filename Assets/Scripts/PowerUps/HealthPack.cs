using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {
	public int healQty;

	void OnTriggerEnter(Collider other) {
        GameObject go = other.gameObject;

		// Guarantee player found
        if(go.GetComponent<Health>()) {
			go.GetComponent<Health>().Heal(healQty);
            Destroy(gameObject);
        }
    }
}
