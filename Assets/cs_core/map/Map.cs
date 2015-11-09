using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {
    ArrayList rooms;
    GameObject[,] roomGrid;
    Dictionary<string, GameObject> roomDict = new Dictionary<string, GameObject>();
    int seed; 
    int size;
    GameObject player;

    // Use this for initialization
    void Start () {
        size = 10;
        roomGrid = new GameObject[size, size];
        
        //grab player object
        player = GameObject.Find("Player");

        seed = System.DateTime.Now.Second;
        Random.seed = seed;

        rooms = new ArrayList();

        for (int i = 0; i < size * 10; i++)
        {
            rooms.Add(GenerateRoom());
            
        }
        int arrayX = 0, arrayY = 0;
        foreach (GameObject obj in rooms)
        {
            roomGrid[arrayX, arrayY] = obj;
            arrayX++;
            if (arrayX == 10) {
                arrayX = 0;
                arrayY++;
            } 

        }
        
        //Vector3 dest = r2.GetDestination("w");
        //r.SetDestination(dest, "w");
        //r.SetDoorActive("west", r3.GetComponent<Room>().wDoor, r3.GetComponent<Room>().eDoor);
        //r2.SetDoorActive("east", r2.eDoor, r.wDoor);
        //r.placePlayer(player);


    }

    public void PlacePlayer(float x, float y)
    {
        //player.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - height);
    }

    /*
    * dir = direction
    * dest = destination
    * src = source
    */
    void RoomTransition(string src, string dest, string dir)
    {
        
    }

    GameObject GenerateRoom()
    {
        int temp = rooms.Count;
        GameObject room = new GameObject();
        room.transform.name = "room" + temp.ToString();
        room.transform.parent = this.transform;
        room.transform.position = new Vector3(temp * 40, 0);
        room.AddComponent<Room>();
        Room r = room.GetComponent<Room>();
        roomDict.Add(room.transform.name, room);
        r.SetDoorActive("east");
        return room;
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
