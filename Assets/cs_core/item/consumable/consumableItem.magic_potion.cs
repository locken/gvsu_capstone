using UnityEngine;
using System.Collections;

public class magic_potion : consumableItem {

	// Use this for initialization
	void Start () {

        itemType = itemTypes.consumable;
        minLevel = 0;
        cooldown = 1;

        consumableType = consumableTypes.magic_potion;
        itemName = "Magic Potion";
        itemID = 320;
        magicModifier = 10 * UnityEngine.Random.Range(1, 10);
        healthModifier = 0;
        attackModifier = 0;
        defenseModifier = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
