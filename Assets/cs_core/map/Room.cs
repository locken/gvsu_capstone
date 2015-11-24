using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {

    GameObject baseTile, playerStartLoc;

    Random r = new Random();
    int length = (int)(Mathf.Round(Random.Range(10, 30) / 2) * 2);
    int height = (int)(Mathf.Round(Random.Range(10, 30) / 2) * 2);
    
    Object[] mapSprites;
    ArrayList floorTiles;
	public Dictionary<string, GameObject> doors = new Dictionary<string, GameObject>();
    string tileset;

    // Use this for initialization
    void Start() {
        baseTile = new GameObject();//nDoor = sDoor = eDoor = eDest = sDest = nDest = new GameObject();
        baseTile.transform.parent = this.transform;//= nDoor.transform.parent = sDoor.transform.parent = eDoor.transform.parent = this.transform;
        //eDest.transform.parent = sDest.transform.parent = nDest.transform.parent = this.transform;
        //ARRAY SIZE = NUMBER OF FOLDERS IN Resources/map
        string[] tilesets = new string[3];
        tilesets[0] = "map/desert/";
        tilesets[1] = "map/dungeon/";
        tilesets[2] = "map/grass/";
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
        //floorTiles.Add(floor02);
       // floorTiles.Add(floor03);
        //floorTiles.Add(floor04);
        //floorTiles.Add(floor05);
        /*** END LOAD ***/

        getFloorSprite(baseTile);

        SpriteRenderer floorSprite = baseTile.GetComponent<SpriteRenderer>();
        float tileLength = floorSprite.bounds.size.x;
        float tileWidth = floorSprite.bounds.size.y;

        
        //placing base tile in bottom left corner of our room.
        baseTile.transform.localPosition = new Vector3(-length / 2, -height / 2 , 0);

        for (int y = 0; y <= height; y++)
        {
           // nextTile = new GameObject();
           // nextTile.transform.position =  new Vector3(baseTile.transform.position.x, baseTile.transform.position.y + y, 0.0f);  
           // currentTile = nextTile;

            for (int x = 0; x <= length; x++)
            {
                if (x == 0 && y == 0)
                {
                    GameObject wall = createCollidable("wallbl", baseTile, x, y);
                }
                else if(x == length && y == 0)
                {
                    GameObject wall = createCollidable("wallbr", baseTile, x, y);

                }
                else if (x == 0 && y == height)
                {
                    GameObject wall = createCollidable("walltl", baseTile, x, y);

                }
                else if (x == length && y == height)
                {
                    GameObject wall = createCollidable("walltr", baseTile, x, y);

                }
                else if (x == 0 | x == length)
                {
                    GameObject wall = createCollidable("wallv", baseTile, x, y);
                }
                else if (y == 0 | y == height)
                {
                    GameObject wall = createCollidable("wallh", baseTile, x, y);
                }
                else
                {
                    GameObject nextTile = (GameObject)Instantiate(baseTile, new Vector3(baseTile.transform.position.x + x, baseTile.transform.position.y + y), Quaternion.identity);
                    nextTile.transform.parent = this.transform;
                    //generate a new ground sprite for this tile
                    getFloorSprite(nextTile);
                }
            }
            Destroy(baseTile);
        }
    }

    public int getLength()
    {
        return length;
    }

    public int getHeight()
    {
        return height;
    }

	public void createDoors() 
	{
		string[] directions = new string[4] {"north", "south", "east", "west"};
		

		foreach(string dir in directions) 
		{
			GameObject door = new GameObject();
			door.transform.name = this.transform.name + " " + dir;
			door.transform.parent = this.transform;
			Door d = (Door)door.AddComponent<Door>();
			doors.Add (dir, d.SetDoorActive(dir, getLength(), getHeight()));
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
