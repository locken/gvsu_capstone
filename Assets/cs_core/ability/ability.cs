using UnityEngine;
using System.Collections;

public abstract class Ability : MonoBehaviour {

    public string id;
    public float cooldown;
    public int magiccost;
    public string origin, target;
    //abstract float castTime;
    
    //abstract bool isCasting();
    public abstract bool cast();


    void setCooldown()
    {

    }
}
