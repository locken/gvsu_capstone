using UnityEngine;
using System.Collections;
using System;

//Cooldown used contextually

public class otherItem : Item {

    public enum otherTypes {Key, Ammunition};

    public override void useItemAction()
    {
        throw new NotImplementedException();
    }

    public otherTypes otherType;

    // Use this for initialization
    void Start () {
        this.itemType = itemTypes.other;
        this.itemID = 400;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
