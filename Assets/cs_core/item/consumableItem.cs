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
        consumableType = consumableTypes.health_potion;
        attackModifier = 0;
        defenseModifier = 0;
        healthModifier = 10;
        magicModifier = 0;
        this.itemType = itemTypes.consumable;
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
