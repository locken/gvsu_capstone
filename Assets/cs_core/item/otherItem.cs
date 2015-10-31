using UnityEngine;
using System.Collections;
using System;

//Cooldown used contextually

public class otherItem : Item {

    public otherItem()
    {
        this.itemType = itemTypes.other;
    }

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
