using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// The main player of the game
	public GameObject player;
	// Offset of the camera to the player
	private Vector3 offset;

    public void SetPlayer(GameObject p)
    {
        player = p;
    }

	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	// Move the camera off of the player
	void LateUpdate(){
		transform.position = player.transform.position + offset;
	}

	// Update is called once per frame
	void Update () {
	
	}
}