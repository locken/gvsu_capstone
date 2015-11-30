using UnityEngine;
using System.Collections;

public class food : consumableItem {

	// Use this for initialization
	void Start () {
        itemType = itemTypes.consumable;
        minLevel = 0;
        cooldown = 1;
        consumableType = consumableTypes.food;
        itemID = 340;
        itemName = "Sandwich";
        attackModifier = UnityEngine.Random.Range(1, 10);
        defenseModifier = UnityEngine.Random.Range(1, 10);
        healthModifier = UnityEngine.Random.Range(1, 10);
        magicModifier = UnityEngine.Random.Range(1, 10);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
