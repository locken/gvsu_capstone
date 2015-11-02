using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    ArrayList rooms;
	// Use this for initialization
	void Start () {
        rooms = new ArrayList();
        GameObject room = new GameObject();
        room.transform.position = new Vector3(0,0);
        GameObject room2 = new GameObject();
        room2.transform.position = new Vector3(20, 20);
        room2.transform.parent = this.transform.parent;
        Room r2 = (Room)room.AddComponent<Room>();
        Room r = (Room)room.AddComponent<Room>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
