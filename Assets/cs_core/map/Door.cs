using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	string name;

	// Use this for initialization
	void Start () {
	
	}


	public GameObject SetDoorActive(string direction, int length, int width)
    {
        //GameObject localActive = new GameObject();
        //activeDoor;

		BoxCollider2D bc = gameObject.AddComponent<BoxCollider2D>();
		bc.isTrigger = true;

		gameObject.AddComponent<SpriteRenderer>();

        Vector3 doorPos = new Vector3();

		float doorX = this.transform.parent.transform.position.x;
		float doorY = this.transform.parent.transform.position.y;

		string trueDir = direction.ToLower();

        switch (trueDir)
        {
		case "north":
            doorPos = new Vector3(doorX, doorY + width / 2);
            break;
        case "south":
            doorPos = new Vector3(doorX, doorY - width / 2);
            break;
        case "east":
            doorPos = new Vector3(doorX + length / 2, doorY);
            break;
        case "west":
			doorPos = new Vector3(doorX - length / 2 , doorY);
            break;
		default:
			doorPos = new Vector3(0,0);
			break;
        }

		gameObject.transform.position = doorPos;
      
		return gameObject;
        //Add sprite later -------------------------------------------------------------------------------------------------------------------------

        //activeDoor.transform.position = doorPos;
        //activeDoor.AddComponent<BoxCollider2D>();
        //activeDoor = localActive;
    }
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D c)
	{
		Debug.Log ("Hit the collider!!");
		if(c.name == "Player")
		{
			SendMessageUpwards("RoomTransition", gameObject);
		}
	}
}
