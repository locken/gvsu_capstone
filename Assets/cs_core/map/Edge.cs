using UnityEngine;
using System.Collections;

public class Edge : MonoBehaviour {

    public int index;
    public GameObject node1, node2;
    public GameObject room1, room2;
    bool isActive;
    public float length;
    public Vector3 point1, point2;
    //line renderer at some point



	// Use this for initialization
	void Start () {
        index = -1;
        isActive = false;
        length = 0.0f;
        point1 = point2 = new Vector3();

	}

    public void toggleActive()
    {
        isActive = !isActive;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
