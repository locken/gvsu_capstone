using UnityEngine;
using System.Collections;
using System;

//cooldown cooresponds to usability rate

public enum consumableTypes { health_potion, magic_potion, stat_potion, food}

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
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
