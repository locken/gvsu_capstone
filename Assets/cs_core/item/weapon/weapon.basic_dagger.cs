using UnityEngine;
using System.Collections;

public class basic_dagger : weaponItem {

	// Use this for initialization
	void Start () {
        itemID = 102;
        itemName = "Basic Dagger";
        itemType = itemTypes.weapon;
        minLevel = 1;
        cooldown = 1;
        weaponDamage = UnityEngine.Random.Range(5, 10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
