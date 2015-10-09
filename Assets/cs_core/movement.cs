using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

    public float speed, maxspeed;
    public Quaternion rot;

	// Use this for initialization
	void Start () {
        speed = 0;
        maxspeed = 5;
        rot = Quaternion.LookRotation(new Vector3(0, 0, 0), Vector3.up);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 0), Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 180), Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 90), Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 270), Vector3.left);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (speed < maxspeed)
                speed += .2f;
            transform.Translate(-1 * speed * Time.deltaTime,0f, 0f,Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (speed < maxspeed)
                speed += .2f;
            transform.Translate(speed*Time.deltaTime,0f, 0f,Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (speed < maxspeed)
                speed += .2f;
            transform.Translate(0f, speed*Time.deltaTime, 0f,Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (speed < maxspeed)
                speed += .2f;
            transform.Translate(0f, -1*speed*Time.deltaTime, 0f,Space.World);
        }
        if(!(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)))
        {
            speed = 0;
        }
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }
}
