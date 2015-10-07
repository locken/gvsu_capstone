using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

    public Inventory itemManager;
    public List<playerItems> items = new List<playerItems>();

    void Start () {
	
	}
	
	void Update () {
	
	}

    public void addItem(int itemId, int itemQuantity)
    {
        for(int i=0; i < itemManager.items.Count; i++)
        {
            if(itemManager.items[i].itemTransform.GetComponent<Item>().itemID == itemId)
            {
                playerItems itemsToAdd = new playerItems(itemManager.items[i].itemTransform.GetComponent<Item>(), itemQuantity);
                items.Add(itemsToAdd);
            }
        }
    }

    [System.Serializable]
    public class playerItems
    {
        public Item item;
        public int itemQuantity;

        public playerItems(Item item, int itemQuantity)
        {
            this.item = item;
            this.itemQuantity = itemQuantity;
        }
    }
}
