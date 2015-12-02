using UnityEngine;
using System.Collections;


public class GenerateItems : MonoBehaviour
{

    int WEAPONTYPES = 2;        //Currently 2 weapon types: knife and sword
    int ARMORTYPES = 1;         //Currently 1 armor type: shield
    int CONSUMABLETYPES = 4;    //Currently 4 consumable types: Health potion, magic potion, stat potion, and food
    int OTHERTYPES = 1;         //Currently 2 other types: Key and Ammunition, however it is set to 1 because we haven't implemented Ammo yet.

    int weaponCount = 0;
    int armorCount = 0;
    int consumableCount = 0;
    int otherCount = 0;

    GameObject temp;

    void Start()
    {
        for(int i=0; i<5; i++)
        {
            for(int j=0; j<5; j++)
            {
                int itemsToGenerate = GetRandomNumItems();
                for(int k=0; k<itemsToGenerate; k++)
                {
                    GenerateItem(i, j);
                }
            }
        }
    }


    int CalPos(int i)
    {
        int temp = 0, value = 0;
        while(temp < i)
        {
            value += 40;
            temp++;
        }
        value += UnityEngine.Random.Range(-4, 4);
        return value;
    }

    void GenerateItem(int i, int j)
    {
        string tempItemType = GetRandomItemType();
        if (tempItemType == "weapon")
        {
            //tempItem = (GameObject)Instantiate(GenerateWeapon(), new Vector3(CalPos(i), CalPos(j), -1), Quaternion.identity);
            GenerateWeapon(i, j);
        }
        else if (tempItemType == "armor")
        {
            GenerateArmor(i, j);
        }
        else if (tempItemType == "consumable")
        {
            GenerateConsumable(i, j);
        }
        else
        {
            GenerateOther(i, j);
        }
    }

    int GetRandomNumItems()
    {
        return Random.Range(0, 3);
    }

    string GetRandomItemType()
    {
        string temp = "";
        int itemType = UnityEngine.Random.Range(1,4);
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

    void GenerateWeapon(int i, int j)
    {
        temp = new GameObject();
        temp.transform.localPosition = new Vector3(CalPos(i), CalPos(j), -1);
        temp.name = "weapon" + weaponCount;
        weaponCount++;
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
    }

    void GenerateArmor(int i, int j)
    {
        temp = new GameObject();
        temp.transform.localPosition = new Vector3(CalPos(i), CalPos(j), -1);
        temp.name = "armor" + armorCount;
        armorCount++;
        SpriteRenderer tempSprite = temp.AddComponent<SpriteRenderer>();
        int type = Random.Range(1, ARMORTYPES);
        if (type == 1)
        {
            temp.AddComponent<basic_shield>();
            tempSprite.sprite = Resources.Load<Sprite>("item/armor/shield");
        }
        BoxCollider2D tempCollider = temp.AddComponent<BoxCollider2D>();
        tempCollider.transform.parent = temp.transform;
    }

    void GenerateConsumable(int i, int j)
    {
        GameObject temp = new GameObject();
        temp.transform.localPosition = new Vector3(CalPos(i), CalPos(j), -1);
        temp.name = "consumable" + consumableCount;
        consumableCount++;
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
    }

    void GenerateOther(int i, int j)
    {
        temp = new GameObject();
        temp.transform.localPosition = new Vector3(CalPos(i), CalPos(j), -1);
        SpriteRenderer tempSprite = temp.AddComponent<SpriteRenderer>();
        temp.name = "other" + otherCount;
        otherCount++;
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
    }
    // Update is called once per frame
    void Update()
    {

    }
}