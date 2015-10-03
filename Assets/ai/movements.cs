using UnityEngine;
using System.Collections;

public class movements : MonoBehaviour
{
	
	public float speed;
	public Quaternion rot;
	public int x;
	public int y;
	public float now;
	
	// Use this for initialization
	void Start ()
	{
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		now = Time.time + 2.0f;
		x = 1;
		y = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > now) {
			x = Random.Range (-1, 2);
			y = Random.Range (-1, 2);
			
			now = Time.time + 2.0f;
			Debug.Log ("X is: " + x);
			Debug.Log ("Y is: " + y);
		}
		float moveHorizontal = (float)x;
		float moveVertical = (float)y;
		Debug.Log ("MoveH is: " + x);
		Debug.Log ("MoveY is: " + y);
		Vector2 movement = new Vector3 (moveHorizontal, moveVertical);
		GetComponent<Rigidbody2D>().velocity = movement * speed;
		
		GetComponent<Rigidbody2D>().position = new Vector2
			(
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.x, -5.0f, 5.0f), 
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.y,  -5.0f, 5.0f)
				);
		
		//GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}