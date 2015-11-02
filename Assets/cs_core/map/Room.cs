using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    GameObject baseTile, playerStartLoc;

    public GameObject nDoor, sDoor, wDoor, eDoor, eDest, wDest, sDest, nDest;

    Random r = new Random();
    float length, height;
    
    Object[] mapSprites;
    ArrayList floorTiles;
    string tileset;

    // Use this for initialization
    void Start() {

        baseTile = new GameObject();//nDoor = sDoor = eDoor = eDest = sDest = nDest = new GameObject();
        baseTile.transform.parent = this.transform;//= nDoor.transform.parent = sDoor.transform.parent = eDoor.transform.parent = this.transform;
        //eDest.transform.parent = sDest.transform.parent = nDest.transform.parent = this.transform;
        wDest = new GameObject();
        wDoor = new GameObject();
        eDest = new GameObject();
        eDoor = new GameObject();
        wDest.transform.parent = this.transform;
        wDoor.transform.parent = this.transform;
        eDest.transform.parent = this.transform;
        eDest.transform.name = "eDest";
        wDest.transform.name = "wDest";
        eDoor.transform.name = "eDoor";
        wDoor.transform.name = "wDoor";
        eDoor.transform.parent = this.transform;
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
        //floorTiles.Add(floor02);
       // floorTiles.Add(floor03);
        //floorTiles.Add(floor04);
        //floorTiles.Add(floor05);
        /*** END LOAD ***/

        //GameObject rock = createCollidable("rock01"/);

        getFloorSprite(baseTile);

        SpriteRenderer floorSprite = baseTile.GetComponent<SpriteRenderer>();
        float tileLength = floorSprite.bounds.size.x;
        float tileWidth = floorSprite.bounds.size.y;

        height = Random.Range(10, 30);
        length = Random.Range(10, 30);
        //placing base tile in bottom left corner of our room.
        baseTile.transform.localPosition = new Vector3(-length / 2, -height / 2 - 0.5f, 0);

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

    public Vector3 GetDestination(string d)
    {
        switch (d)
        {
            case "w":
                return new Vector3(0, length / 2);
            default:
                return new Vector3(0, -length / 2);
        }
    }

    public void SetDestination(Vector3 v, string d)
    {
        //wDest = new GameObject();
        //wDoor = new GameObject();
        //eDest = new GameObject();
        //eDoor = new GameObject();
        switch (d)
        {
            case "w":
                wDest.transform.position = v;
                break;
            default:
                wDest.transform.position = v;
                break;
        }
    }

   public void SetDoorActive(string direction, GameObject activeDoor, GameObject destDoor)
    {
        //GameObject localActive = new GameObject();
        //activeDoor;
        Vector3 doorPos;
        switch (direction)
        {
            case "north":
                nDest = destDoor;
                 doorPos = new Vector3(0, 0);
                //activeDoor.name = "nDoor";
                break;
            case "south":
                sDest = destDoor;
                doorPos = new Vector3(0, 0);
                //activeDoor.name = "sDoor";
                break;
            case "east":
                doorPos = new Vector3(0,length / 2);
                eDest = destDoor;
                //activeDoor.transform.name = "eDoor";
                break;
            case "west":
                doorPos = new Vector3(0, -length / 2);
                wDest = destDoor;
                //activeDoor.transform.name = "wDoor";
                //Debug.Log(localActive.transform.name);
                break;
            default:
                doorPos = new Vector3(0, 0);
                break;
        }
        activeDoor.transform.position = doorPos;
        activeDoor.AddComponent<BoxCollider2D>();
        //activeDoor = localActive;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("aldfj");
        if(c.name == "eDoor")
        {
            c.gameObject.transform.position = eDest.transform.position;
        } else if (c.name == "wDoor")
        {
            c.gameObject.transform.position = wDest.transform.position;
        }
        else if (c.name == "nDoor")
        {
            c.gameObject.transform.position = eDest.transform.position;
        }
        else if (c.name == "sDoor")
        {
            c.gameObject.transform.position = eDest.transform.position;
        }
    }

   public void placePlayer(GameObject player)
    {
        player.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - height);
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
