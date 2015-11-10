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


        int arrayCol = 0, arrayRow = 0, currentRoom = 0;
		for(int i=0; i<size * size; i++)
        {
            roomGrid[arrayCol, arrayRow] = GenerateRoom(arrayCol, arrayRow, currentRoom);
            arrayCol++;
            if (arrayCol == 10) {
                arrayCol = 0;
                arrayRow++;
            } 
			currentRoom = arrayRow * 10 + arrayCol;
        }
		drawFunkyLines();
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
    void RoomTransition(GameObject obj)
    {
		string[] splitString = obj.transform.name.Split();
		string roomName = splitString[0];
		string doorDir = splitString[1]; 
    }

    GameObject GenerateRoom(int col, int row, int roomNum)
    {
        GameObject room = new GameObject();
        room.transform.name = "room" + roomNum.ToString();
        room.transform.parent = this.transform;

		room.transform.position = new Vector3(col * 40, row * 40);
        room.AddComponent<Room>();
        Room r = room.GetComponent<Room>();
		r.createDoors();
		roomDict.Add(room.transform.name, room);
       	
        return room;
    }

	void drawFunkyLines() 
	{
		for(int row = 0; row < size; row++) 
		{
			for(int col = 0; col < size; col++) 
			{
				GameObject curr = roomGrid[col,row];
				GameObject vertSrc, vertDest = null;
				GameObject horSrc, horDest = null;

				Dictionary<string, GameObject> doors = (roomGrid[col,row].GetComponent<Room>()).doors;

				if (col + 1 < size)
				{
					//Debug.Log ("East Vector3 Door Location for " + roomGrid[col,row].transform.name + ": " + doors["east"].transform.position); 
					//Debug.DrawLine(roomGrid[col,row].transform.position]
					horSrc = doors["east"];
					GameObject eastNeighbor = roomGrid[col+1,row];
					horDest = ((Room)(eastNeighbor.GetComponent<Room>())).doors["west"];
					Debug.DrawLine (horSrc.transform.position, horDest.transform.position,Color.white, 5, false);
					//GameObject westNeighbor = roomGrid[col-1,row];
				}


				if(row + 1 < size)
				{
					Debug.Log (row);
					vertSrc = doors["north"];
					GameObject northNeighbor = roomGrid[col,row+1];
					vertDest = ((Room)(northNeighbor.GetComponent<Room>())).doors["south"];
					Debug.Log (vertSrc.transform.position + " " + vertDest.transform.position);
					Debug.DrawLine (vertSrc.transform.position, vertDest.transform.position,Color.red, 5, false);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
