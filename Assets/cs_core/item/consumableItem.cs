using UnityEngine;
using System.Collections;
using System;

//cooldown cooresponds to usability rate

public enum consumableTypes { health_potion, magic_potion, stat_potion, food, ammunition, key }

public class consumableItem : Item {
   
    public consumableTypes consumableType;
    public int attackModifier;
    public int defenseModifier;
    public int healthModifier;
    public int magicModifier;
    //Implement all constructors for all types of weapons. 
    
    public override void useItemAction()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        this.itemType = itemTypes.consumable;
        this.minLevel = 0;
        this.cooldown = 1;
        int consumableTypeNum = UnityEngine.Random.Range(1, 5);
        if (consumableTypeNum == 0)
        {
            this.consumableType = consumableTypes.health_potion;
            this.itemSprite = loadSprite("health_potion");
            this.itemName = "Health Potion";
            this.itemID = 310;
            healthModifier = 10 * UnityEngine.Random.Range(1, 10);
            magicModifier = 0;
            attackModifier = 0;
            defenseModifier = 0;
        }
        else if (consumableTypeNum == 1)
        {
            this.consumableType = consumableTypes.magic_potion;
            this.itemSprite = loadSprite("magic_potion");
            this.itemName = "Magic Potion";
            this.itemID = 320;
            magicModifier = 10 * UnityEngine.Random.Range(1, 10);
            healthModifier = 0;
            attackModifier = 0;
            defenseModifier = 0;
        }
        else if (consumableTypeNum == 2)
        {
            this.consumableType = consumableTypes.stat_potion;
            this.itemSprite = loadSprite("stat_potion");
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
        else if (consumableTypeNum == 3)
        {
            this.consumableType = consumableTypes.food;
            this.itemSprite = loadSprite("food");
            this.itemID = 340;
            this.itemName = "Sandwich";
            attackModifier = UnityEngine.Random.Range(1, 10);
            defenseModifier = UnityEngine.Random.Range(1, 10);
            healthModifier = UnityEngine.Random.Range(1, 10);
            magicModifier = UnityEngine.Random.Range(1, 10);
        }
        else if (consumableTypeNum == 4)
        {
            this.consumableType = consumableTypes.ammunition;
            attackModifier = 0;
            defenseModifier = 0;
            healthModifier = 0;
            magicModifier = 0;
        }
        else
        {
            this.consumableType = consumableTypes.key;
            this.itemSprite = loadSprite("key");
            this.itemID = 360;
            this.itemName = "Key";
            attackModifier = 0;
            defenseModifier = 0;
            healthModifier = 0;
            magicModifier = 0;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
