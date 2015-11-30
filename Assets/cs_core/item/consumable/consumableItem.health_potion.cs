using UnityEngine;
using System.Collections;

public class health_potion : consumableItem {

	// Use this for initialization
	void Start () {

        itemType = itemTypes.consumable;
        minLevel = 0;
        cooldown = 1;
        consumableType = consumableTypes.health_potion;
        itemName = "Health Potion";
        itemID = 310;
        healthModifier = 10 * UnityEngine.Random.Range(1, 10);
        magicModifier = 0;
        attackModifier = 0;
        defenseModifier = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
