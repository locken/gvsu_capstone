using UnityEngine;
using System.Collections;


public class GenerateItems : MonoBehaviour {

    //Object[] array = Resources.LoadAll("item/consumable");
    // Use this for initialization

    

        //Create base item and use Instantiate function for real new items then destroy the base. 
    void Start () {
        string spritePath;
        Random.seed = System.DateTime.UtcNow.Second;
        int itemsToGenerate = GetRandomNumItems();
        int[] usedX = new int[itemsToGenerate];
        int[] usedY = new int[itemsToGenerate];
        for (int i = 0; i < itemsToGenerate; i++)
        {
            string tempItemType = GetRandomItemType();
            GameObject itemGenerate = new GameObject();
            itemGenerate.name = "item" + i;
            if(tempItemType == "weapon")
            {
                itemGenerate.AddComponent<weaponItem>();
                spritePath = "item/weapon/dagger";
            }
            else if(tempItemType == "armor")
            {
                itemGenerate.AddComponent<armorItem>();
                spritePath = "item/armor/armorSpritesheet";
            }
            else if(tempItemType == "consumable")
            {
                spritePath = "item/consumable/food";
                itemGenerate.AddComponent<consumableItem>();
            }
            else
            {
                spritePath = "item/weapon/dagger";
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
            SpriteRenderer itemF_sr = itemFinal.AddComponent<SpriteRenderer>();
            itemF_sr.sprite = Resources.Load<Sprite>(spritePath);
            itemFinal.transform.localScale += new Vector3(4.0F, 4.0F);
            //BoxCollider2D itemF_bc = itemFinal.AddComponent<BoxCollider2D>();
            Destroy(itemGenerate);
        }

        /*Object[] array = Resources.LoadAll("item/consumable");
		Debug.Log ("Array Length: " + array[0]);
        GameObject item01 = new GameObject();
        SpriteRenderer item01sprite = item01.AddComponent<SpriteRenderer>();
        item01.name = "item01";
       // item01sprite.sprite = (Sprite)array[1];
        GameObject item02 = (GameObject)Instantiate(item01, new Vector3(3.0f, 4.0f), Quaternion.identity);
        Destroy(item01);*/
    }

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
    //between size 0 and 5. In the future we should get the room size and manipulate the bounds
    // use for both x and y position
    int GetRandomPos()
    {
        return Random.Range(0, 5);

    }
	// Update is called once per frame
	void Update () {
	
	}
}
