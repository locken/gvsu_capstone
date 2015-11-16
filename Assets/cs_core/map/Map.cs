using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {
    ArrayList rooms;
    GameObject[,] roomGrid;
    Dictionary<string, GameObject> roomDict = new Dictionary<string, GameObject>();
   //Dictionary<int, obj> door connections. each door will be assigned a unique index, lookup its destination obj.
   

    int seed; 
    int size;
    GameObject player;

    // Use this for initialization
    void Start () {
        size = 5;
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
            if (arrayCol == size) {
                arrayCol = 0;
                arrayRow++;
            } 
			currentRoom = arrayRow * size + arrayCol;
        }
		createEdges();
    }
    
    public void PlacePlayer(Vector3 dest)
    {
        player.transform.position = dest;
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
		GameObject src = roomDict[roomName];
		GameObject dest = roomDict["room4"];
		PlacePlayer(dest.transform.position);
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
					horSrc = doors["east"];
					GameObject eastNeighbor = roomGrid[col+1,row];
					horDest = ((Room)(eastNeighbor.GetComponent<Room>())).doors["west"];
					Debug.DrawLine (horSrc.transform.position, horDest.transform.position,Color.green, 5, true);
					//GameObject westNeighbor = roomGrid[col-1,row];
				}


				if(row + 1 < size)
				{
					//Debug.Log (row);
					vertSrc = doors["north"];
					GameObject northNeighbor = roomGrid[col,row+1];
					vertDest = ((Room)(northNeighbor.GetComponent<Room>())).doors["south"];
					//Debug.Log (vertSrc.transform.position + " " + vertDest.transform.position);
					Debug.DrawLine (vertSrc.transform.position, vertDest.transform.position, Color.white, 5, true);
				}
			}
		}
	}

    void createEdges()
    {
        int index = 0;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                GameObject curr = roomGrid[col, row];
                GameObject vertSrc, vertDest = null;
                GameObject horSrc, horDest = null;

                Dictionary<string, GameObject> doors = (roomGrid[col, row].GetComponent<Room>()).doors;


                if (col + 1 < size)
                {
                    GameObject edge = new GameObject();
                    Edge e = (Edge)edge.AddComponent<Edge>();
                    e.toggleActive();
                    e.index = index;

                    index++;
                    horSrc = doors["east"];
                    GameObject eastNeighbor = roomGrid[col + 1, row];
                    horDest = ((Room)(eastNeighbor.GetComponent<Room>())).doors["west"];

                    e.node1 = horSrc;
                    e.node2 = horDest;
                    e.room1 = roomGrid[col, row];
                    e.room2 = roomGrid[col + 1, row];
                    Debug.DrawLine(horSrc.transform.position, horDest.transform.position, Color.green, 5, true);

                }

                if (row + 1 < size)
                {
                    GameObject edge = new GameObject();
                    Edge e = (Edge)edge.AddComponent<Edge>();
                    e.toggleActive();
                    e.index = index;

                    index++;
                    vertSrc = doors["north"];
                    GameObject northNeighbor = roomGrid[col, row + 1];
                    vertDest = ((Room)(northNeighbor.GetComponent<Room>())).doors["south"];

                    e.node1 = vertSrc;
                    e.node2 = vertDest;
                    e.room1 = roomGrid[col, row];
                    e.room2 = roomGrid[col, row+1];
                    Debug.DrawLine(vertSrc.transform.position, vertDest.transform.position, Color.white, 5, true);

                }
                Debug.Log(index);
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}