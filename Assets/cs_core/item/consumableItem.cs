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

    public override void useItemAction()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
