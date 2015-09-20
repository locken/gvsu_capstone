using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

    public float speed;
    public Quaternion rot;

	// Use this for initialization
	void Start () {
        speed = 5;
        rot = Quaternion.LookRotation(new Vector3(270, 0, 0), Vector3.down);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
	}

    // Update is called once per frame
    void Update()
    {
        //var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        if (Input.GetAxis("Horizontal") > 0)
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 90), Vector3.right);
            transform.Translate(0f, Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 270), Vector3.left);
            transform.Translate(0f, -Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 0), Vector3.up);
            transform.Translate(0f, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0f);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            rot = Quaternion.LookRotation(new Vector3(0, 0, 180), Vector3.down);
            transform.Translate(0f, -Input.GetAxis("Vertical") * Time.deltaTime * speed, 0f);
        }
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        
        //transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*speed, Input.GetAxis("Vertical")*Time.deltaTime*speed, 0f);
    }
}
