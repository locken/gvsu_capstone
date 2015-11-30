using UnityEngine;
using System.Collections;

public class basic_shield : armorItem {

	// Use this for initialization
	void Start () {
        itemID = 201;
        itemName = "Basic Shield";
        itemType = itemTypes.armor;
        minLevel = 1;
        cooldown = 1;

        durability = UnityEngine.Random.Range(1, 20);
        armorType = armorTypes.shield;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
