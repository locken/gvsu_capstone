using UnityEngine;
using System.Collections;

public abstract class Ability : MonoBehaviour {

    public string id;
    //abstract float cooldown;
    //abstract float castTime;
    
    //abstract bool isCasting();
    public abstract bool cast();


    void setCooldown()
    {

    }
}
