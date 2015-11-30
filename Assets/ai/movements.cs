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
	public bool NotTouchingAi; 
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
		NotTouchingAi = true;
		speed = 15;
		GetComponent<Rigidbody2D> ().drag = 10;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!collision && !playerCollision) {
			if (Time.time > now) {
				x = Random.Range (-1, 2);
				y = Random.Range (-1, 2);

				now = Time.time + Random.Range (1.0f, 3.0f);
				//currentSpeed = 0;
			}
		} else if (collision && NotTouchingAi) {
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
			NotTouchingAi = false;
		} else if (playerCollision) {
			//Debug.Log("PLAYER FOUND");
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

		Vector2 positionVector = GetComponent<Rigidbody2D> ().position;
		if (y > 0) {
			rot = Quaternion.LookRotation (new Vector3 (0, 0, 0), Vector3.up);
			positionVector.y = 1f;

			//transform.Translate (0f, currentSpeed * Time.deltaTime, 0f, Space.World);
		} else 
		if (y < 0) {
			rot = Quaternion.LookRotation (new Vector3 (0, 0, 180), Vector3.down);
			positionVector.y = -1f;
			//GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * currentSpeed * Time.deltaTime);
			//transform.Translate (0f, -1 * currentSpeed * Time.deltaTime, 0f, Space.World);
		} else {
			positionVector.y = 0f;
		}

		if (x > 0) {
			rot = Quaternion.LookRotation (new Vector3 (0, 0, 90), Vector3.right);
			positionVector.x = 1f;
			//transform.Translate (currentSpeed * Time.deltaTime, 0f, 0f, Space.World);
		} else
		if (x < 0) {
			rot = Quaternion.LookRotation (new Vector3 (0, 0, 270), Vector3.left);
			positionVector.x = -1f;
			//transform.Translate (-1 * currentSpeed * Time.deltaTime, 0f, 0f, Space.World);
		} else {
			positionVector.x = 0f;
		}


		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		Vector2 movementVector = new Vector2 (positionVector.x, positionVector.y);
		//Debug.Log ("X: " + positionVector.x + "\nY: " + positionVector.y + "\nSpeed: " + currentSpeed);
		GetComponent<Rigidbody2D> ().AddForce (movementVector * speed, ForceMode2D.Force);
		//GetComponent<Rigidbody2D> ().MovePosition (transform.position + transform.forward * Time.deltaTime);
	}
	
	public float GetSpeed()
	{
		return FlockingSpeed;
	}
}