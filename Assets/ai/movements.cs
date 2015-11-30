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
	public Attack attack;
	public Transform target;

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
		speed = 20;
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
		} else if (collision && NotTouchingAi && !playerCollision) {
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
		} 
		if (playerCollision) {

			/*if (collisionRight) {
				x = 1;
			} else {
				x = -1;
			}
			if (collisionUp) {
				y = 1;
			} else {
				y = -1;
			}
			x = 0;
			y = 0;*/

			target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
			//rotate to look at the player
			//transform.LookAt(target.position);
			//transform.Rotate(new Vector3(0, -90,0),Space.Self);//correcting the original rotation

			/*Quaternion rotation = Quaternion.LookRotation
				(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
			rotation.x = 0;
			rotation.y = 0;
			transform.rotation = rotation;*/

			Vector3 dir = target.position - transform.position;
			float angle = (Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg) - 90;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				//new Quaternion(0, 0, rotation.z, rotation.w);


			//move towards the player
			if (Vector3.Distance(transform.position,target.position)>1f){//move if distance from target is greater than 1
				if(transform.position.x > target.position.x)
				{
					x = -1;
				} else{
					x = 1;
				}

				if(transform.position.y > target.position.y)
				{
					y = -1;
				} else{
					y = 1;
				}

				GetComponent<Rigidbody2D> ().AddForce (new Vector2(x,y) * speed, ForceMode2D.Force );
			}

			
		} else {
			
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
			GetComponent<Rigidbody2D> ().AddForce (movementVector * speed, ForceMode2D.Force);
			//GetComponent<Rigidbody2D> ().MovePosition (transform.position + transform.forward * Time.deltaTime);
		}

	}

	void OnCollisionEnter2D(Collision2D  other) {
		if(other.gameObject.tag == "Player");
		{
			playerCollision = true;

			collisionRight = this.transform.position.x > other.transform.position.x;
			collisionUp = this.transform.position.y > other.transform.position.y;
	}

	
	}

	void OnCollisisonExit2D(Collision2D  other) {
		if (other.gameObject.tag == "Player") {
			playerCollision = false;
		}
	}

	public float GetSpeed()
	{
		return FlockingSpeed;
	}
}