using UnityEngine;
using System.Collections;

public class GenerateItems : MonoBehaviour {

    //Object[] array = Resources.LoadAll("item/consumable");
    // Use this for initialization

        //Create base item and use Instantiate function for real new items then destroy the base. 
    void Start () {
        Random.seed = System.DateTime.UtcNow.Second;
        Object[] array = Resources.LoadAll("item/consumable");
        GameObject item01 = new GameObject();
        SpriteRenderer item01sprite = item01.AddComponent<SpriteRenderer>();
        item01.name = "item01";
        item01sprite.sprite = (Sprite)array[1];
        GameObject item02 = (GameObject)Instantiate(item01, new Vector3(3.0f, 4.0f), Quaternion.identity);
        Destroy(item01);

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
        //Based on random number, change temp to consumable or weapon or armor ... etc
        return temp;
    }
    //between size 1 and 9
    // use for both x and y position
    int GetRandomPos()
    {
        return 0;

    }
	// Update is called once per frame
	void Update () {
	
	}
}
