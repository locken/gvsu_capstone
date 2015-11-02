using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    ArrayList rooms;
    int seed;
    // Use this for initialization
    void Start () {
        //grab player object
        GameObject player = GameObject.Find("Player");

        seed = System.DateTime.Now.Second;
        Random.seed = seed;

        rooms = new ArrayList();

        GameObject room = new GameObject();
        GameObject room2 = new GameObject();
        room.transform.name = "room1";
        room.transform.parent = this.transform;
        room2.transform.parent = this.transform;
        room2.transform.name = "room2";
        room.transform.position = new Vector3(0, 0);
        room2.transform.position = new Vector3(-40, 0);

        Room r = (Room)room.AddComponent<Room>();
        Room r2 = (Room)room2.AddComponent<Room>();
        //Vector3 dest = r2.GetDestination("w");
        //r.SetDestination(dest, "w");
        //r.SetDoorActive("west", r3.GetComponent<Room>().wDoor, r3.GetComponent<Room>().eDoor);
       // r2.SetDoorActive("east", r2.eDoor, r.wDoor);
        r.placePlayer(player);

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
