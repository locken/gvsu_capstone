using UnityEngine;
using System.Collections;

public class stat_potion : consumableItem {

	// Use this for initialization
	void Start () {
        minLevel = 0;
        itemType = itemTypes.consumable;
        cooldown = 1;

        this.consumableType = consumableTypes.stat_potion;
        int statType = UnityEngine.Random.Range(1, 3);
        if (statType == 1)
        {
            this.itemName = "Power Potion";
            this.itemID = 330;
            attackModifier = UnityEngine.Random.Range(1, 15);
            defenseModifier = 0;
        }
        else if (statType == 2)
        {
            this.itemName = "Toughness Potion";
            this.itemID = 331;
            attackModifier = 0;
            defenseModifier = UnityEngine.Random.Range(1, 15);
        }
        else
        {
            this.itemName = "Super Stat Potion";
            this.itemID = 332;
            attackModifier = UnityEngine.Random.Range(1, 15);
            defenseModifier = UnityEngine.Random.Range(1, 15);
        }
        healthModifier = 0;
        magicModifier = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
