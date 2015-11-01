using UnityEngine;
using System.Collections;


public class GenerateItems : MonoBehaviour {

    //Object[] array = Resources.LoadAll("item/consumable");
    // Use this for initialization

    

        //Create base item and use Instantiate function for real new items then destroy the base. 
    void Start () {
        Random.seed = System.DateTime.UtcNow.Second;
//<<<<<<< Updated upstream
        int itemsToGenerate = GetRandomNumItems();
        int[] usedX = new int[itemsToGenerate];
        int[] usedY = new int[itemsToGenerate];
        for (int i = 0; i < itemsToGenerate; i++)
        {
            string tempItemType = GetRandomItemType();
            //Object[] array = Resources.LoadAll("item/" + tempItemType);
            GameObject itemGenerate = new GameObject();
            SpriteRenderer itemGenerateSprite = itemGenerate.AddComponent<SpriteRenderer>();
            itemGenerate.name = "item" + i;
            //itemGenerateSprite.sprite = (Sprite)array[1];
            if(tempItemType == "weapon")
            {
                itemGenerate.AddComponent<weaponItem>();
            }
            else if(tempItemType == "armor")
            {
                itemGenerate.AddComponent<armorItem>();
            }
            else if(tempItemType == "consumable")
            {
                itemGenerate.AddComponent<consumableItem>();
            }
            else
            {
                itemGenerate.AddComponent<otherItem>();
            }
            int newX = GetRandomPos();
            int newY = GetRandomPos();
            if (i != 0)
            {
                for(int j = 0; j < i; j++)
                {
                    if((newX == usedX[j])&&(newY == usedY[j]))
                    {
                        newX = GetRandomPos();
                        newY = GetRandomPos();
                        j = 0;
                    }
                }
            }
            GameObject itemFinal = (GameObject)Instantiate(itemGenerate, new Vector3(newX, newY), Quaternion.identity);
            usedX[i] = newX;
            usedY[i] = newY;
            Destroy(itemGenerate);
        }
//=======
        Object[] array = Resources.LoadAll("item/consumable");
		Debug.Log ("Array Length: " + array[0]);
        GameObject item01 = new GameObject();
        SpriteRenderer item01sprite = item01.AddComponent<SpriteRenderer>();
        item01.name = "item01";
       // item01sprite.sprite = (Sprite)array[1];
        GameObject item02 = (GameObject)Instantiate(item01, new Vector3(3.0f, 4.0f), Quaternion.identity);
        Destroy(item01);

//>>>>>>> Stashed changes
        //Based on random number of items, get % 3 item types, use those types for the two arrays of loadall from resources.  
    }
	//based on the number of items do toString for item name.
    int GetRandomNumItems()
    {
        return Random.Range(1,4);
    }

    string GetRandomItemType()
    {
        string temp = "";
        int itemType = GetRandomNumItems();
        if (itemType == 1)
        {
            temp = "weapon";
        }
        else if(itemType == 2)
        {
            temp = "armor";
        }
        else if(itemType == 3)
        {
            temp = "consumable";
        }
        else
        {
            temp = "other";
        }
        return temp;
    }
    //between size 1 and 9
    // use for both x and y position
    int GetRandomPos()
    {
        return Random.Range(1, 9);

    }
	// Update is called once per frame
	void Update () {
	
	}
}
