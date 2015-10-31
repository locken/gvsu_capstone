using UnityEngine;
using System.Collections;
using System;

//cooldown cooresponds to invincibility frames

public class armorItem : Item {

    public int durability;
    
 

    public override void useItemAction()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		this.itemType = itemTypes.armor;
		durability = UnityEngine.Random.Range(1, 15);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
