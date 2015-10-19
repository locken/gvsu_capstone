using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    GameObject ground;
    Random r = new Random();
    float length, height;
    int seed;
    Walls roomWalls;
    Object[] mapSprites;

    public class Walls {
        public GameObject topWall = new GameObject();
        public GameObject bottomWall = new GameObject();
        public GameObject rock = new GameObject();
        float wallThickness;
        Object[] mapSprites;

        public Walls(float length, float height, float layer) {
            mapSprites = Resources.LoadAll("map");
            //set the wall thickness here
            wallThickness = 3.0f;
            //uses sprites width to create new length of wall
            topWall.transform.position = new Vector3(0, height / 2, layer);
            topWall.transform.localScale = new Vector3(1, 1);
            bottomWall.transform.position = new Vector3(0, -height / 2, layer);
            bottomWall.transform.localScale = new Vector3(length, wallThickness);

            rock.transform.position = new Vector3(0, 0, layer);
            rock.transform.localScale = new Vector3(3, 3, 1);

            createWall(topWall);
            createWall(bottomWall);
            createRock(rock);
            topWall.name = "topWall";
            bottomWall.name = "bottomWall";
            rock.name = "rock";
            Debug.Log("Top and Bottom Wall Size: " + length + "x" + wallThickness);
            Debug.Log("Z Axis: " + layer);
        }

        SpriteRenderer createWall(GameObject wall)
        {
            //add spriterenderer
            SpriteRenderer wallSprite = wall.AddComponent<SpriteRenderer>();
            wallSprite.sprite = (Sprite)mapSprites[3];

            BoxCollider2D wallBody = wall.AddComponent<BoxCollider2D>();

            return wallSprite;
        }

        SpriteRenderer createRock(GameObject rock)
        {
            SpriteRenderer rockSprite = rock.AddComponent<SpriteRenderer>();
            rockSprite.sprite = (Sprite)mapSprites[5];

            BoxCollider2D rockBody = rock.AddComponent<BoxCollider2D>();
            return rockSprite;
        }
    }

    // Use this for initialization
    void Start() {

        mapSprites = Resources.LoadAll("map");
        ground = new GameObject();

        //length = 16;
        //height = 6;

        GameObject rock = new GameObject();
        SpriteRenderer rockSprite = rock.AddComponent<SpriteRenderer>();
        rockSprite.sprite = (Sprite)mapSprites[17];
        BoxCollider2D rockBody = rock.AddComponent<BoxCollider2D>();


        createGround(ground);

        SpriteRenderer groundSprite = ground.GetComponent<SpriteRenderer>();

        float tileLength = groundSprite.bounds.size.x;
        float tileWidth = groundSprite.bounds.size.y;

        //ground.transform.position = new Vector3(-length/2, -height/2 - 0.5f, 0);

        //our "random" seed heh
        seed = System.DateTime.Now.Second;
        Random.seed = seed;
        //length = Random.Range(15, 25);
        //height = Random.Range(20, 30);
        //length = 16;
        height = Random.Range(10, 30);
        length = Random.Range(10, 30);
        ground.transform.position = new Vector3(-length / 2, -height / 2 - 0.5f, 0);


        //roomWalls = new Walls(length, height, -10);
        GameObject tracked = ground;
        GameObject newGround;
        for (int i = 0; i <= height + 1; i++)
        {
            //createGround(ground);
            if (i > 0)
            {
                newGround = (GameObject)Instantiate(tracked, new Vector3(ground.transform.position.x, ground.transform.position.y + i), Quaternion.identity);
                tracked = newGround;
            }

            for (int j = 1; j <= length; j++)
            {
                //createGround(newGround);
                newGround = (GameObject)Instantiate(tracked, tracked.transform.position + Vector3.right, Quaternion.identity);
                createGround(newGround);
                tracked = newGround;
                //yield return new WaitForSeconds(0.001F);
                //StartCoroutine(Wait(0.065F));
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

    SpriteRenderer createGround(GameObject ground)
    {
        SpriteRenderer groundSprite = ground.GetComponent<SpriteRenderer>();
        if (groundSprite == null)
        {
            groundSprite = ground.AddComponent<SpriteRenderer>();
        }
        groundSprite.sprite = (Sprite)mapSprites[GetFloorNum()];
        //int temp = GetFloorNum();
        return groundSprite;
    }
    int GetFloorNum()
    {
        int temp = 2;
        while (temp % 2 == 0) {
            temp = Random.Range(3, 15);
        }
        Debug.Log(temp);
        return temp;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
