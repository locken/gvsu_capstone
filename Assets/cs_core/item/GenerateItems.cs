using UnityEngine;
using System.Collections;


public class GenerateItems : MonoBehaviour
{

    int WEAPONTYPES = 2;        //Currently only 2 weapon types: knife and sword
    int ARMORTYPES = 1;         //Currently only 1 armor type: shield
    int CONSUMABLETYPES = 4;    //Currently only 4 consumable types: Health potion, magic potion, stat potion, and food
    int OTHERTYPES = 2;         //Currently only 2 other types: Key and Ammunition

    void Start()
    {
        Random.seed = System.DateTime.UtcNow.Second;
        int itemsToGenerate = GetRandomNumItems();
        int[] usedX = new int[itemsToGenerate];
        int[] usedY = new int[itemsToGenerate];
        for (int i = 0; i < itemsToGenerate; i++)
        {
            string tempItemType = GetRandomItemType();
            GameObject itemGenerate = new GameObject();
            if (tempItemType == "weapon")
            {
                itemGenerate = GenerateWeapon();
            }
            else if (tempItemType == "armor")
            {
                itemGenerate = GenerateArmor();
            }
            else if (tempItemType == "consumable")
            {
                itemGenerate = GenerateConsumable();
            }
            else
            {
                itemGenerate = GenerateOther();
            }
            itemGenerate.name = "item" + i;

            int newX = GetRandomPos();
            int newY = GetRandomPos();
            if (i != 0)
            {
                for (int j = 0; j < i; j++)
                {
                    if ((newX == usedX[j]) && (newY == usedY[j]))
                    {
                        newX = GetRandomPos();
                        newY = GetRandomPos();
                        j = 0;
                    }
                }
            }
            GameObject itemFinal = (GameObject)Instantiate(itemGenerate, new Vector3(newX, newY, -1), Quaternion.identity);
            usedX[i] = newX;
            usedY[i] = newY;
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
        return Random.Range(1, 4);
    }

    string GetRandomItemType()
    {
        string temp = "";
        int itemType = GetRandomNumItems();
        if (itemType == 1)
        {
            temp = "weapon";
        }
        else if (itemType == 2)
        {
            temp = "armor";
        }
        else if (itemType == 3)
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

    GameObject GenerateWeapon()
    {
        GameObject temp = new GameObject();
        SpriteRenderer tempSprite = temp.AddComponent<SpriteRenderer>();
        int type = Random.Range(1, WEAPONTYPES);
        if (type == 1)
        {
            temp.AddComponent<basic_dagger>();
            tempSprite.sprite = Resources.Load<Sprite>("item/weapon/dagger");
        }
        else
        {
            temp.AddComponent<basic_sword>();
            tempSprite.sprite = Resources.Load<Sprite>("item/weapon/basic_sword");
        }
        BoxCollider2D tempCollider = temp.AddComponent<BoxCollider2D>();
        tempCollider.transform.parent = temp.transform;
        return temp;
    }

    GameObject GenerateArmor()
    {
        GameObject temp = new GameObject();
        SpriteRenderer tempSprite = temp.AddComponent<SpriteRenderer>();
        int type = Random.Range(1, ARMORTYPES);
        if (type == 1)
        {
            temp.AddComponent<basic_shield>();
            tempSprite.sprite = Resources.Load<Sprite>("item/armor/shield");
        }
        BoxCollider2D tempCollider = temp.AddComponent<BoxCollider2D>();
        tempCollider.transform.parent = temp.transform;
        return temp;
    }

    GameObject GenerateConsumable()
    {
        GameObject temp = new GameObject();
        SpriteRenderer tempSprite = temp.AddComponent<SpriteRenderer>();
        int type = Random.Range(1, CONSUMABLETYPES);
        if (type == 1)
        {
            temp.AddComponent<health_potion>();
            tempSprite.sprite = Resources.Load<Sprite>("item/consumable/health_potion");
        }
        else if (type == 2)
        {
            temp.AddComponent<magic_potion>();
            tempSprite.sprite = Resources.Load<Sprite>("item/consumable/magic_potion");

        }
        else if (type == 3)
        {
            temp.AddComponent<stat_potion>();
            tempSprite.sprite = Resources.Load<Sprite>("item/consumable/stat_potion");

        }
        else
        {
            temp.AddComponent<food>();
            tempSprite.sprite = Resources.Load<Sprite>("item/consumable/food");
        }
        BoxCollider2D tempCollider = temp.AddComponent<BoxCollider2D>();
        tempCollider.transform.parent = temp.transform;
        return temp;
    }

    GameObject GenerateOther()
    {
        GameObject temp = new GameObject();
        SpriteRenderer tempSprite = temp.AddComponent<SpriteRenderer>();
        int type = Random.Range(1, OTHERTYPES);
        if (type == 1)
        {
            temp.AddComponent<key>();
            tempSprite.sprite = Resources.Load<Sprite>("item/other/key");
        }
        else
        {

        }
        BoxCollider2D tempCollider = temp.AddComponent<BoxCollider2D>();
        tempCollider.transform.parent = temp.transform;
        return temp;
    }
    // Update is called once per frame
    void Update()
    {

    }
}