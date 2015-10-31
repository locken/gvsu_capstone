using UnityEngine;
using System.Collections;

public class movements : MonoBehaviour
{
	
	public float speed;
	public float currentSpeed;
	public Quaternion rot;
	public int x;
	public int y;
	public float now;
	private bool engaged; 
	public bool collision;
	public bool playerCollision;
	public float FlockingSpeed;
	public bool collisionRight;
	public bool collisionUp;
	// Use this for initialization
	void Start ()
	{
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		now = Time.time + 2.0f;
		x = Random.Range (-1, 2);
		y = Random.Range (-1, 2);
		engaged = false;
		FlockingSpeed = speed;
		collision = false;
		playerCollision = false;
		collisionRight = false;
		collisionUp = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log("AI Num: " + this.tag + "\nCollision \nRight: " + collisionRight + "\nLeft: " + collisionUp);
		if (!collision || !playerCollision) {
			if (Time.time > now) {
				x = Random.Range (-1, 2);
				y = Random.Range (-1, 2);

				now = Time.time + Random.Range (1.0f, 3.0f);
				currentSpeed = 0;
			}
		} else if (collision) {
			Debug.Log ("AI Num: " + this.tag + "\nCollision \nRight: " + collisionRight + "\nUp: " + collisionUp);
			if (collisionRight) {
				x = -1;
			} else {
				x = 1;
			}
			if (collisionUp) {
				y = -1;
			} else {
				y = 1;
			}
		} else if (playerCollision) {
			Debug.Log("PLAYER FOUND");
			if (collisionRight) {
				x = 1;
			} else {
				x = -1;
			}
			if (collisionUp) {
				y = 1;
			} else {
				y = -1;
			}

		}

		if (y > 0) {
			rot = Quaternion.LookRotation (new Vector3 (0, 0, 0), Vector3.up);
			if (currentSpeed < speed)
				currentSpeed += .2f;
			transform.Translate (0f, currentSpeed * Time.deltaTime, 0f, Space.World);
		}
		if (y < 0) {
			rot = Quaternion.LookRotation (new Vector3 (0, 0, 180), Vector3.down);
			if (currentSpeed < speed)
				currentSpeed += .2f;
			transform.Translate (0f, -1 * currentSpeed * Time.deltaTime, 0f, Space.World);
		}
		if (x > 0) {
			rot = Quaternion.LookRotation (new Vector3 (0, 0, 90), Vector3.right);
			if (currentSpeed < speed)
				currentSpeed += .2f;
			transform.Translate (currentSpeed * Time.deltaTime, 0f, 0f, Space.World);
		}
		if (x < 0) {
			rot = Quaternion.LookRotation (new Vector3 (0, 0, 270), Vector3.left);
			if (currentSpeed < speed)
				currentSpeed += .2f;
			transform.Translate (-1 * currentSpeed * Time.deltaTime, 0f, 0f, Space.World);
		}
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D> ().position = new Vector2
			(
				Mathf.Clamp (GetComponent<Rigidbody2D> ().position.x, -5.0f, 5.0f), 
				Mathf.Clamp (GetComponent<Rigidbody2D> ().position.y, -5.0f, 5.0f)
		);
	}
	
	public float GetSpeed()
	{
		return FlockingSpeed;
	}
}