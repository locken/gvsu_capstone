using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour{
    private float cooldown = 1.0f;
    public string itemName;
    public int itemID;
    public string itemType;

    public abstract void useItemAction();
}
