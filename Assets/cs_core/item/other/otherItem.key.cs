using UnityEngine;
using System.Collections;

public class key : otherItem {

	// Use this for initialization
	void Start () {
        itemID = 401;
        itemName = "key";
        itemType = itemTypes.other;
        minLevel = 0;
        cooldown = 1;

        otherType = otherTypes.Key;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
