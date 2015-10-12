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

    /* loadSprite will load a sprite into a SpriteRenderer. Used by weapons, maybe armor.
        @param String spriteName - the name of the sprite we're loading
            
        @return sr - the sprite renderer of the sprite we've loaded
    */
    public SpriteRenderer loadSprite(string spriteName)
    {
        //creates and adds a new sprite renderer to 'this' G.O.
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        //set sprite = to Resources/item/itemType/spriteName
        sr.sprite = (Sprite)Resources.Load("item/" + itemType + "/" + spriteName);
        //return the SpriteRenderer
        return sr;
    }

}
