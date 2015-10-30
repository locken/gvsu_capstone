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
    public consumableItem()
    {
        this.itemType = itemTypes.consumable;
        int consumableTypeNum = UnityEngine.Random.Range(1, 5);
        if (consumableTypeNum == 0)
        {
            this.consumableType = consumableTypes.health_potion;
            healthModifier = 10 * UnityEngine.Random.Range(1, 10);
            magicModifier = 0;
            attackModifier = 0;
            defenseModifier = 0;
        }
        else if (consumableTypeNum == 1)
        {
            this.consumableType = consumableTypes.magic_potion;
            magicModifier = 10 * UnityEngine.Random.Range(1, 10);
            healthModifier = 0;
            attackModifier = 0;
            defenseModifier = 0;
        }
        else if (consumableTypeNum == 2)
        {
            this.consumableType = consumableTypes.stat_potion;
            int statType = UnityEngine.Random.Range(1, 3);
            if (statType == 1)
            {
                attackModifier = UnityEngine.Random.Range(1, 15);
                defenseModifier = 0;
            }
            else if(statType == 2)
            {
                attackModifier = 0;
                defenseModifier = UnityEngine.Random.Range(1, 15);
            }
            else
            {
                attackModifier = UnityEngine.Random.Range(1, 15);
                defenseModifier = UnityEngine.Random.Range(1, 15);
            }
            healthModifier = 0;
            magicModifier = 0;
        }
        else if (consumableTypeNum == 3)
        {
            this.consumableType = consumableTypes.food;
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
            attackModifier = 0;
            defenseModifier = 0;
            healthModifier = 0;
            magicModifier = 0;
        }
        
        
    }

    public override void useItemAction()
    {
        throw new NotImplementedException();
    }

    //Create getter and setter to beef up stats of item if we want. 

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
