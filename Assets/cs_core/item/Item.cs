using UnityEngine;
using System.Collections;

public enum itemTypes {weapon, armor, consumable, other};

/* itemID will coorespond to the item and its subtypes (if applicable)
 * Weapon = 1xx
 * Armor = 2xx
 * Consumable = 3xx
 * Other = 4xx
 * 
 * itemName is assigned in the start method of the item subclasses
 * 
 * itemType is assigned in the start method of the item subclasses
 * 
 * minLevel for weapon and armor are assigned in the subclasses, and
 * defaults to 0 for consumable and other since requiring a high level
 * to use something like a key or a potion seems silly.
 */

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
        sr.sprite = Resources.Load<Sprite>("item/" + itemType + "/" + spriteName);
        //return the SpriteRenderer
        return sr;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"&&gameObject.transform.parent == null)
        {
            other.gameObject.GetComponent<PlayerInventory>().addItem(itemID, 1);
            Destroy(gameObject);
        }
    }

}
