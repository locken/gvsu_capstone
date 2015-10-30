using UnityEngine;
using System.Collections;


public class Fireball : Ability
{
    void Start()
    {
        id = "fireball";
    }

    public override bool cast()
    {
        GameObject obj = Instantiate(gameObject);

        Fireball copy = (Fireball) obj.GetComponent(typeof(Fireball));
        //set cooldown
        return true;
    }

    void Update()
    {
        
    }
}