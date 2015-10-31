using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    GameObject baseTile;
    Random r = new Random();
    float length, height;
    int seed;
    Object[] mapSprites;
    ArrayList floorTiles;
    string tileset;

    // Use this for initialization
    void Start() {
        seed = System.DateTime.Now.Second;
        Random.seed = seed;
        this.transform.name = "room";

        baseTile = new GameObject();

        //ARRAY SIZE = NUMBER OF FOLDERS IN Resources/map
        string[] tilesets = new string[1];
        tilesets[0] = "map/desert/";
        int tsIndex= Random.Range(0, tilesets.Length);
        tileset = tilesets[tsIndex];



        /*** LOAD SPRITES ***/
        floorTiles = new ArrayList();

        Sprite wallv = Resources.Load<Sprite>(tileset + "wallv");
        Sprite wallh = Resources.Load<Sprite>(tileset + "wallh");
        Sprite walltr = Resources.Load<Sprite>(tileset + "walltr");
        Sprite wallbr = Resources.Load<Sprite>(tileset + "wallbr");
        Sprite walltl = Resources.Load<Sprite>(tileset + "walltl");
        Sprite wallbl = Resources.Load<Sprite>(tileset + "wallbl");
        Sprite floor01 = Resources.Load<Sprite>(tileset + "floor01");
        Sprite floor02 = Resources.Load<Sprite>(tileset + "floor02");
        Sprite floor03 = Resources.Load<Sprite>(tileset + "floor03");
        Sprite floor04 = Resources.Load<Sprite>(tileset + "floor04");
        Sprite floor05 = Resources.Load<Sprite>(tileset + "floor05");

        floorTiles.Add(floor01);
        floorTiles.Add(floor02);
        floorTiles.Add(floor03);
        floorTiles.Add(floor04);
        floorTiles.Add(floor05);
        /*** END LOAD ***/

        //GameObject rock = createCollidable("rock01"/);

        getFloorSprite(baseTile);

        SpriteRenderer floorSprite = baseTile.GetComponent<SpriteRenderer>();
        float tileLength = floorSprite.bounds.size.x;
        float tileWidth = floorSprite.bounds.size.y;

        height = Random.Range(10, 30);
        length = Random.Range(10, 30);
        baseTile.transform.position = new Vector3(-length / 2, -height / 2 - 0.5f, 0);

        GameObject currentTile = baseTile;
        GameObject nextTile;
        for (int y = 0; y <= height + 1; y++)
        {
            nextTile = new GameObject();
            nextTile.transform.position =  new Vector3(baseTile.transform.position.x, baseTile.transform.position.y + y, 0.0f);  
            currentTile = nextTile;

            for (int x = 0; x <= length; x++)
            {

                if (x == 0 | x == length)
                {
                    GameObject wall = createCollidable("wallv", baseTile, x, y);
                }
                else if (y == 0 | y == height)
                {
                    GameObject wall = createCollidable("wallh", baseTile, x, y);
                }
                else
                {
                    nextTile = (GameObject)Instantiate(currentTile, currentTile.transform.position + Vector3.right, Quaternion.identity);
                    nextTile.transform.parent = this.transform;
                    getFloorSprite(nextTile);
                    currentTile = nextTile;
                }


                
            }
        }
    }

    //for the wait function
    IEnumerator Wait(float duration)
    {
        //This is a coroutine
        Debug.Log("Start Wait() function. The time is: " + Time.time);
        Debug.Log("Float duration = " + duration);
        yield return new WaitForSeconds(duration);   //Wait
        Debug.Log("End Wait() function and the time is: " + Time.time);
    }

    SpriteRenderer getFloorSprite(GameObject floorObj)
    {
        SpriteRenderer sr = floorObj.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            sr = floorObj.AddComponent<SpriteRenderer>();
        }
        sr.sprite = (Sprite)floorTiles[Random.Range(0,floorTiles.Count)];
        return sr;
    }

	
	// Update is called once per frame
	void Update () {
	
	}

    GameObject createCollidable(string name, GameObject baseTile, int x, int y)
    {
        GameObject retVal = new GameObject();
        retVal.transform.name = name;
        retVal.transform.parent = this.transform;
        retVal.transform.position = new Vector3(baseTile.transform.position.x + x, baseTile.transform.position.y + y, 0.0f);
        
        
       

        SpriteRenderer retSprite = retVal.AddComponent<SpriteRenderer>();
        retSprite.sprite = Resources.Load<Sprite>(tileset + name);
        BoxCollider2D collider = retVal.AddComponent<BoxCollider2D>();
        return retVal;
    }
}
