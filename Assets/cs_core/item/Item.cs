using UnityEngine;
using System.Collections;

public enum itemTypes {weapon, armor, consumable, other};

public abstract class Item : MonoBehaviour{
    public int itemID;
    public string itemName;
    public itemTypes itemType;
    public int minLevel;
    public float cooldown;
    
    public abstract void useItemAction();
}
