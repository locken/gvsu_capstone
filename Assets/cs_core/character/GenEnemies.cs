using UnityEngine;
using System.Collections;

public class GenEnemies : MonoBehaviour {

    int enemyCount, roomIndex, localDimension;
    GameObject localMap;
    GameObject[] enemyArray;
    bool generate;
    // Use this for initialization
    void Start() {
        generate = true;
        localMap = GameObject.Find("Map");
        enemyCount = 0;
        roomIndex = 0;
    }

    GameObject GenerateEnemy(int i, int rl, int rh)
    {
        GameObject enemy = new GameObject();
        SpriteRenderer enemySprite = new SpriteRenderer();
        BoxCollider2D enemyCollider = new BoxCollider2D();
        //Maybe dont need this?
        CircleCollider2D enemyCirCollide = new CircleCollider2D();
        enemy.AddComponent<movements>();
        enemy.AddComponent<FlockingAlgorithm>();
        enemy.AddComponent<Rigidbody2D>();
        enemy.AddComponent<AI_Attributes>();
        enemy.GetComponent<FlockingAlgorithm>().seperation = 1;
        enemy.GetComponent<movements>().speed = UnityEngine.Random.Range(5, 15);
        enemySprite = enemy.AddComponent<SpriteRenderer>();
        enemyCirCollide = enemy.AddComponent<CircleCollider2D>();
        enemyCollider = enemy.AddComponent<BoxCollider2D>();
        enemySprite.sprite = Resources.Load<Sprite>("enemy");
        enemyCount++;
        enemy.name = "enemy" + enemyCount.ToString();
       
        enemy.transform.parent = this.transform;
        enemy.transform.localPosition = new Vector3(CalPos(rl), CalPos(rh), -1);
        return enemy;
    }

	//This method is to calculate the room position based on the 
    //dimensions of the map.
    int CalPos(int i)
    {
        int temp = 0, value = 0;
        while (temp < i)
        {
            value += 40;
            temp++;
        }
        value += UnityEngine.Random.Range(-4, 4);
        return value;
    }

    // Update is called once per frame
    void Update () {
	    if(generate)
        {
            localDimension = localMap.GetComponent<Map>().getMapDimension();
            enemyArray = new GameObject[3 * (localDimension * localDimension)];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int localRH = localMap.GetComponent<Map>().getRoomsH(roomIndex);
                    int localRL = localMap.GetComponent<Map>().getRoomsL(roomIndex);
                    if (localRH > 15 && localRL > 15)
                    {
                        enemyArray[enemyCount] = GenerateEnemy(roomIndex, i, j);

                    }
                    if (localRH > 21 && localRL > 21)
                    {
                        enemyArray[enemyCount] = GenerateEnemy(roomIndex, i, j);
                    }
                    if (localRH > 25 && localRL > 25)
                    {
                        enemyArray[enemyCount] = GenerateEnemy(roomIndex, i, j);
                    }
                    roomIndex++;
                }
            }
            generate = false;
        }
	}
}
