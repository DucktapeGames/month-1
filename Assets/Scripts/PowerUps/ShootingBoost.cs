﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBoost : PowerUp {
	// Shooting component is used to guarantee the powerup is in possesion of the player
	// or to guarantee that the player will posses it
	public string displayName = "Shooting Boost";
   
    // Use this for initialization
    void Start() {
        // Guarantee existance in player or in game
        if(!GetComponent<Shooting>()) {
            SphereCollider col = GetComponent<SphereCollider>();
            if(!GetComponent<Collider>()) {
                col = gameObject.AddComponent<SphereCollider>();
            }
            col.radius = 0.5f;
            col.isTrigger = true;
            isActive = false;
        }
    }
   
    public override void Init() {
        toolTip = displayName;
       
        if(GetComponent<Shooting>()) {
            // Make this the current active powerup
            PowerUp[] pups = (PowerUp[])GetComponents<PowerUp>();

            foreach(PowerUp pup in pups) {
				pup.isActive = false;
			}
            isActive = true;
        }
    }
   
    // Update is called once per frame
    void Update () {
        if(!GetComponent<Shooting>()) {
            // do animation effects here.
            return;
        }
       
        if(isPassive) {
            DoPowerUp();
        }

		else if(isActive) {
            if(Input.GetButtonDown("Jump")){
                DoPowerUp ();
            }
        }
    }
   
    // handle the trigger enter stuff and update the player
    void OnTriggerEnter(Collider other) {
        GameObject go = other.gameObject;

		// Guarantee player found
        if(go.GetComponent<Shooting>()) {
			// If plyaer already has an active shooting boost
            if(go.GetComponent<ShootingBoost>()) {
                Destroy(go.GetComponent<ShootingBoost>());
            }
            // Create the new PowerUp
            PowerUp po = go.AddComponent<ShootingBoost>();
            // Pass values to override the defaults in the new instance
            po.icon = icon;
            po.iconPosition = iconPosition;
            po.uses = uses;

            // If it is the only PowerUp then it should be active
            po.Init();

            Destroy(gameObject);
        }
    }
   
    void DoPowerUp() {
        //Debug.Log("uses available: " + uses);
        uses--;
        if(uses == 0) {
            //Debug.Log("Ended");
            Destroy(GetComponent<ShootingBoost>());
        }
    }
}
