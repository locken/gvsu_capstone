using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

    public float speed;
    int x, y;
    float move1, move2;
    public Quaternion rot;

	// Use this for initialization
	void Start () {
        speed = 5;
        move1 = Time.deltaTime * speed;
        move2 = 0;
        x = 1;
        y = 1;
        rot = Quaternion.LookRotation(new Vector3(0, 0, 0), Vector3.up);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
	}

    // Update is called once per frame
    void Update()
    {
        //var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1* x * move1, -1* y * move2, 0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 270), Vector3.left);
            move1 = 0;
            move2 = Time.deltaTime * speed;
            x = 1;
            y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(x * move1, y * move2, 0f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 90), Vector3.right);
            move1 = 0;
            move2 = Time.deltaTime * speed;
            x = -1;
            y = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(x * move2, y * move1, 0f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 0), Vector3.up);
            move1 = Time.deltaTime * speed;
            move2 = 0;
            x = 1;
            y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1* x * move2, -1 * y * move1, 0f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 180), Vector3.down);
            move1 = Time.deltaTime * speed;
            move2 = 0;
            x = -1;
            y = -1;
        }
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        
        //transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*speed, Input.GetAxis("Vertical")*Time.deltaTime*speed, 0f);
    }
}
