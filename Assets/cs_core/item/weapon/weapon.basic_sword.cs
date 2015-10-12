using UnityEngine;
using System.Collections;

/*   BASIC SWORD FOR DEMO AND TEMPLATE   */

public class basic_sword : weaponItem {

    
        

    // Use this for initialization
    void Start () {
        //item attributes
        itemName = "Basic Sword";
       // itemType = weapon; ?
        minLevel = 1;
        cooldown = 1.0f;

        //weapon attributes
        weaponDamage = 1;

        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
