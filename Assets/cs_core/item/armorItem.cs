using UnityEngine;
using System.Collections;
using System;

//cooldown cooresponds to invincibility frames

public class armorItem : Item {

    public int durability;
    public enum armorTypes { shield, not_shield };
    public armorTypes armorType;

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
