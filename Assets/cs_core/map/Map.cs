using UnityEngine;
using System.Collections;

public class Map: MonoBehaviour {
    Random r = new Random();
    int length, height;
    int seed;
    Walls roomWalls;
    SpriteRenderer s;

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
            topWall.transform.position = new Vector3(0, height/2, layer);
            topWall.transform.localScale = new Vector3(length * 4, wallThickness);
            bottomWall.transform.position = new Vector3(0, -height / 2, layer);
            bottomWall.transform.localScale = new Vector3(length * 4, wallThickness);

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
	void Start () {
        s = gameObject.GetComponent<SpriteRenderer>();
        //our "random" seed heh
        seed = 69;
        Random.seed = seed;
        length = Random.Range(15, 25);
        height = Random.Range(20, 30);

        roomWalls = new Walls(s.bounds.size.x, s.bounds.size.y, -10);
        Debug.Log("Seed: " + seed);
        Debug.Log("Map Size: " + length + 'x' + height);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
