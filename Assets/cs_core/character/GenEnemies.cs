using UnityEngine;
using System.Collections;

public class GenEnemies : MonoBehaviour {

    int enemyCount, roomIndex, localDimension;
    GameObject localMap;
    GameObject[] enemyArray;
	public Object []spriteHolder;
    bool generate;
	//right hand variables
	public GameObject rightHand;
	public weaponItem rightHandItem;
	public SpriteRenderer rightSr;
	public BoxCollider2D rightBc;
	private float wpnz = 0;
	private float wpnx = 18 / 24f;
	private bool attack = false;
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
        enemy.AddComponent<Attributes>();
		enemy.AddComponent<Attack> ();
		enemy.AddComponent<Fireball> ();
		spriteHolder = Resources.LoadAll("pc");
        enemy.GetComponent<FlockingAlgorithm>().seperation = 1;
        enemy.GetComponent<movements>().speed = UnityEngine.Random.Range(5, 15);
        enemySprite = enemy.AddComponent<SpriteRenderer>();
        enemyCirCollide = enemy.AddComponent<CircleCollider2D>();
        enemyCollider = enemy.AddComponent<BoxCollider2D>();
        enemySprite.sprite = Resources.Load<Sprite>("enemy");
        enemyCount++;
        enemy.name = "enemy" + enemyCount.ToString();
		enemy.tag = "Enemy";
        enemy.transform.parent = this.transform;
        enemy.transform.localPosition = new Vector3(CalPos(rl), CalPos(rh), -1);

		//add rightHand to player
		GameObject rightHand = new GameObject();
		//rightHand.tag = "RightHand";
		rightHand.name = "Right Hand";
        rightHand.tag = "Enemy";
		rightHand.transform.parent = enemy.transform;
		rightHandItem = rightHand.AddComponent<basic_sword>();
		rightSr = rightHand.AddComponent<SpriteRenderer>();
		
		spriteHolder = Resources.LoadAll("item/weapon");
		rightSr.sprite = (Sprite)spriteHolder[1];
		
		rightHand.transform.localPosition = new Vector3(18 / 24f, 18 / 24f, 0);
		rightHand.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, wpnz), Vector3.up);
		rightBc = rightHand.AddComponent<BoxCollider2D>();
		rightBc.isTrigger = true;
		
		rightHand.AddComponent<damage>();
		rightHand.SendMessage("setWeapon", rightHandItem);

		enemy.GetComponent<Attack> ().rightHand = rightHand;
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

		Transform target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
		foreach (GameObject enemies in GameObject.FindGameObjectsWithTag("Enemy")) {
			if (Vector3.Distance (enemies.transform.position, target.position) < 2f) {

				enemies.GetComponent<Attack>().rightHand.SetActive(true);
				if (wpnz < 15) {
					wpnz++;
					for (int i = 0; i < 10; i++) {
						enemies.GetComponent<Attack>().rightHand.transform.Rotate (0, 0, 1);
						wpnx = wpnx - ((2 / 3f) / 150f);
						enemies.GetComponent<Attack>().rightHand.transform.localPosition = new Vector3 (wpnx, 18 / 24f, 0f);
					}

				} else {
					wpnz = 0;
					enemies.GetComponent<Attack>().rightHand.transform.localRotation = Quaternion.LookRotation (new Vector3 (0, 0, wpnz), Vector3.up);
					wpnx = 18 / 24f;
					enemies.GetComponent<Attack>().rightHand.transform.localPosition = new Vector3 (wpnx, 18 / 24f, 0f);
					//rightHand.SendMessage ("ClearArray");
					enemies.GetComponent<Attack>().rightHand.SetActive (false);
					GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Attributes>().Health--;
                    
					Debug.Log ("player health: " + GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Attributes> ().Health);
				}

			} //else if(Vector3.Distance (enemies.transform.position, target.position) < 4f){ 

				//enemies.GetComponent<Fireball>().cast();
			//}
		}

		}
}
