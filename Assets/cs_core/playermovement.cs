using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour {

    public float speed, maxspeed;
    public Quaternion rot;
    public Vector2 movementVector;
    public int direction;

	// Use this for initialization
	void Start () {
        speed = 0;
        maxspeed = 45;
        movementVector = new Vector2();
        rot = Quaternion.LookRotation(new Vector3(0, 0, 0), Vector3.up);
        direction = 1;
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 0), Vector3.up);
            direction = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 180), Vector3.down);
            direction = 3;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 90), Vector3.right);
            direction = 4;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 270), Vector3.left);
            direction = 2;
        }
		//Vector2 movementVector = new Vector2();
        if (Input.GetKey(KeyCode.A))
        {
            if (speed < maxspeed)
                speed += 1f;
			movementVector.x = -1;

            //transform.Translate(-1 * speed * Time.deltaTime,0f, 0f,Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (speed < maxspeed)
                speed += 1f;
			movementVector.x = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (speed < maxspeed)
                speed += 1f;
			movementVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (speed < maxspeed)
                speed += 1f;
			movementVector.y = -1;;
        }
        if(!(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)))
        {
            speed = 0;
            movementVector.x = 0;
            movementVector.y = 0;
        }
		GetComponent<Rigidbody2D> ().AddForce(movementVector * speed, ForceMode2D.Force);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }
}
