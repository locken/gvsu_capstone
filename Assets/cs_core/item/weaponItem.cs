using UnityEngine;
using System.Collections;
using System;

//cooldown cooresponds to attack rate

public class weaponItem : Item {

    /***********************
    TO DO ISSUE 18:

        Create sprite renderer
        Load sprite
        Add collider

    ***********************/
    
    public int weaponDamage;
	

    public override void useItemAction()
    {
        throw new NotImplementedException();
    }



    // Use this for initialization
    void Start () {
		this.itemType = itemTypes.weapon;
		weaponDamage = UnityEngine.Random.Range(1, 15);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    
}
