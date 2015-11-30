using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {
    ArrayList rooms;
    GameObject[,] roomGrid;
    Dictionary<string, GameObject> roomDict = new Dictionary<string, GameObject>();
    Dictionary<string, string> doorDict = new Dictionary<string, string>();// door connections. each door will be assigned a unique index, lookup its destination obj.

    int[] roomsL, roomsH;
    int size, index, seed;
    GameObject player;

    public int getMapDimension()
    {
        return size;
    }

    public int getRoomsL(int i)
    {
        return roomsL[i];
    }

    public int getRoomsH(int i)
    {
        return roomsH[i];
    }

    // Use this for initialization
    void Start () {
        size = 5;
        index = 0;
        roomsH = new int[size * size];
        roomsL = new int[size * size];
        roomGrid = new GameObject[size, size];
        
        //grab player object
        player = GameObject.Find("Player");

        seed = System.DateTime.Now.Second;
        Random.seed = seed;

        rooms = new ArrayList();


        int arrayCol = 0, arrayRow = 0, currentRoom = 0;
		for(int i=0; i<size * size; i++)
        {
            int dirIndex = 0;
            string[] directions = new string[4];


            if (arrayRow != size - 1)
            {
                directions[dirIndex] = "north";
                dirIndex++;
            }
            if (arrayCol != size - 1)
            {
                directions[dirIndex] = "east";
                dirIndex++;
            }
            if (arrayRow > 0)
            {
                directions[dirIndex] = "south";
                dirIndex++;
            }
            if (arrayCol > 0)
            { 
                directions[dirIndex] = "west";
            }
            

            roomGrid[arrayCol, arrayRow] = GenerateRoom(arrayCol, arrayRow, currentRoom, directions);

            createDestinations(directions, i);

            arrayCol++;
            if (arrayCol == size) {
                arrayCol = 0;
                arrayRow++;
            } 
			currentRoom = arrayRow * size + arrayCol;
        }
		//createEdges();
    }
    

    public void createDestinations(string[] directions, int roomNum)
    {
        Debug.Log("creating stuff for roomdict room: " + roomNum);
        foreach(string dir in directions)
        {
            if (dir != null)
            {

            
            string destDoor = "room";
            int destRoom = roomNum;
            string destDir = "";
            string srcDoor = "room" + roomNum.ToString();
            switch (dir)
            {
                case "north":
                    destRoom += size;
                    destDir = " south";
                    srcDoor += " north";
                    break;
                case "east":
                    destRoom += 1;
                    destDir = " west";
                    srcDoor += " east";
                    break;
                case "south":
                    destRoom -= size;
                    destDir = " north";
                    srcDoor += " south";
                    break;
                case "west":
                    destRoom -= 1;
                    destDir = " east";
                    srcDoor += " west";
                    break;
                default:
                    break;
            }
            destDoor += destRoom.ToString();
            destDoor += destDir;

            doorDict.Add(srcDoor, destDoor);
            }
        }
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
        string destStr = doorDict[obj.transform.name];
        GameObject dest = GameObject.Find(destStr);

        float offset = 1.75f;
        float xDest = dest.transform.position.x;
        float yDest = dest.transform.position.y;
        switch(doorDir)
        {
            case "north":
                yDest += offset;
                break;
            case "east":
                xDest += offset;
                break;
            case "south":
                yDest -= offset;
                break;
            case "west":
                xDest -= offset;
                break;
            default:
                break;
        }

        Vector3 newPos = new Vector3(xDest, yDest, -1);
		PlacePlayer(newPos);
    }

    GameObject GenerateRoom(int col, int row, int roomNum, string[] directions)
    {
        GameObject room = new GameObject();
        room.transform.name = "room" + roomNum.ToString();
        room.transform.parent = this.transform;

		room.transform.position = new Vector3(col * 40, row * 40);
        room.AddComponent<Room>();
        Room r = room.GetComponent<Room>();
		r.createDoors(directions);
		roomDict.Add(room.transform.name, room);
        roomsH[index] = r.getHeight();
        roomsL[index] = r.getLength();
        index++;
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