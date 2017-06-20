using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	[HideInInspector]
    public string toolTip = "Power Up";
   
    public bool displayIcon = true;
    public Texture2D icon;
    public Vector2 iconPosition = Vector3.zero;
    public int uses = 5; // Quantity of uses in case of an active power up
   
    [HideInInspector]
    public bool isActive = false; // Set to true in case of a usage power up
    [HideInInspector]
    public bool isPassive = false; // Set to true in case of a stat power up
    public float passiveLifetime = 20; // Lifetime of a passive power up
    [HideInInspector]
    public float dieAt = 0;
   
   
    public virtual void Init() {
        if(isPassive) {
            Destroy(this, passiveLifetime);
            dieAt = Time.time + passiveLifetime;
        }
		else {
            isActive = true;
        }
    }
    public void Dectivate() {
		isActive = false;
	}
   
    // Show power up data on gui
    void OnGUI() {
        //In order to show power up stats we need a display icon in true
        if(!displayIcon) {
			return;
		}
        // We also need an icon
        if(!icon) {
			return;
		}
        // Just show on GUI if its in possesion of the player
        if(!GetComponent<Health>()) { 
			return;
		}
        // Color to use in GUI, white for now
        Color c = Color.white;
        if(!isActive || isPassive) {
			c.a = 0.5f;
		}

        GUI.color = c;
       
       // Show quantity of uses while there are available
        string s = "";
        if(uses > 0) {
			s = uses.ToString();
		}

        GUIContent content = new GUIContent(icon, toolTip);
        
        Rect rect = new Rect(iconPosition.x, iconPosition.y, icon.width, icon.height);
        GUI.Box(rect, content);
        s = ""; // uses or seconds remaining

        if(uses > 0) {
			s = uses.ToString();
		}

        if(isPassive) {
            float t = dieAt - Time.time;
            s = (Mathf.Round((dieAt - Time.time) * 10.0f) / 10.0f).ToString();
            if(t > 1) {
                s = (Mathf.Floor(dieAt - Time.time)).ToString();
            }
        }

        if(s != "") {
            GUI.color = Color.white;
            GUI.Label (rect, s);
        }
    }
}
