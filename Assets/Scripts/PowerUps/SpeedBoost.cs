using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PowerUp {
	// Movement component is used to guarantee the powerup is in possesion of the player
	// or to guarantee that the player will posses it
	public string displayName = "Speed Boost";
    float prevSlowness;
    float prevTurnVelocity;
    float prevTilt;
    float prevMultiplier;
   
    // Use this for initialization
    void Start() {
        if(!GetComponent<Movement>()) {
            SphereCollider col = GetComponent<SphereCollider>();
            if(!GetComponent<SphereCollider>()) {
                col = gameObject.AddComponent<SphereCollider>();
            }
            col.radius = 0.5f;
            col.isTrigger = true;
            isActive = false;
        }
    }
   
    public override void Init() {
        toolTip = displayName;
        isPassive = true; // is a passive power up
        iconPosition = Vector2.right * 100;

       
        if(GetComponent<Movement>()) {
            prevSlowness = GetComponent<Movement>().Slowness;
            prevTurnVelocity = GetComponent<Movement>().TurningVelocity;
            prevTilt = GetComponent<Movement>().TiltVelocity;
            prevMultiplier = GetComponent<Movement>().Multiplier;
            GetComponent<Movement>().Slowness = 10;
            GetComponent<Movement>().TurningVelocity = 250;
            GetComponent<Movement>().TiltVelocity = 50;
            GetComponent<Movement>().Multiplier = 6;
            Destroy(this, passiveLifetime);
        	dieAt = Time.time + passiveLifetime;
        }
    }
   
    // Update is called once per frame
    void Update() {
        if(!GetComponent<Movement>()) {
            // do animation effects here.
            return;
        }
       
        if(isPassive) {
            DoPowerUp();
        }
		else if(isActive) {
            if(Input.GetButtonDown("Jump")) {
                DoPowerUp ();
            }
        }
    }
   
    // handle the trigger enter stuff and update the player
    void OnTriggerEnter(Collider other) {
        GameObject go = other.gameObject;

        if(go.GetComponent<Movement>()) {
            if(go.GetComponent<SpeedBoost>()){
                Destroy(go.GetComponent<SpeedBoost>());
            }
            // Create the new PowerUp
            PowerUp po = go.AddComponent<SpeedBoost>();
            // Pass values to override the defaults in the new instance
            po.iconPosition = iconPosition;
            po.icon = icon;
            po.passiveLifetime = passiveLifetime;
            //Debug.Log (po);
           
            po.Init();
           
            Destroy(gameObject);
        }
    }
   
    void DoPowerUp() {
        if((Mathf.Round((dieAt - Time.time) * 10.0f) / 10.0f) < 0.2) {
            GetComponent<Movement>().Slowness = prevSlowness;
            GetComponent<Movement>().TurningVelocity = prevTurnVelocity;
            GetComponent<Movement>().TiltVelocity = prevTilt;
            GetComponent<Movement>().Multiplier = prevMultiplier;
        }
    }
}
