using UnityEngine;
using System.Collections;

public class FlockingAlgorithm : MonoBehaviour {
	public float seperation;
	public float alignnment; 
	public float cohesion;
	public static bool collision;
	public static float x;
	public static float y;
	public movements movementScript;
	void Start()
	{
		CircleCollider2D collider = GetComponent<CircleCollider2D> ();
		//collider.radius = seperation;
		//AI_Attributes.Engaged = false; 
		collision = false;
		movementScript = new movements ();
	}

	void OnCollisionEnter2D(Collision2D  other) {

		try{
			//anim.SetTrigger("Attack");
			if (other != null && other.gameObject != null && other.gameObject.tag == "Enemy") {
			    movementScript = other.gameObject.GetComponent<movements>();
				movementScript.collision = true;
				Collider2D collider = other.collider;
				if(collider.name.Contains("Enemy"))
				{ 				
					movementScript.collisionRight = other.gameObject.GetComponent<Rigidbody2D>().position.x >
						this.gameObject.GetComponent<Rigidbody2D>().position.x;
					movementScript.collisionUp = other.gameObject.GetComponent<Rigidbody2D>().position.y >
						this.gameObject.GetComponent<Rigidbody2D>().position.y;
				}
			}
			if(other != null && other.gameObject != null && other.gameObject.tag == "Player")
			{
				//Debug.Log("Gerad!!!! movementScript.playerCollision1: " + movementScript.playerCollision);
				//GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
				//enemyAttributes.Engaged = true;
				//enemyAttributes.Health -= 10;
				//if(enemyAttributes.Health <= 0){
				//	Destroy(enemyAttributes.gameObject);
				//}
				//Debug.Log(other.name + ": " + enemyAttributes.Health);

			}
		}catch(MissingReferenceException ex){
			
		}
		/*Vector2 enemyPosition = GetComponent<Rigidbody2D> ().position;
		float x;
		float y;
		if (enemyPosition.x >= other.attachedRigidbody.position.x) {
			x = -1;
		} else {
			x = 1;
		}
		if (enemyPosition.y >= other.attachedRigidbody.position.y) {
			y = -1;
		} else {
			y = 1;
		}

		Vector2 movement = new Vector3 (x, y);
		float speed = movements.GetSpeed ();
		GetComponent<Rigidbody2D> ().velocity = movement * speed;
		GetComponent<Rigidbody2D> ().position = new Vector2
			(
				Mathf.Clamp (GetComponent<Rigidbody2D> ().position.x, -5.0f, 5.0f), 
				Mathf.Clamp (GetComponent<Rigidbody2D> ().position.y, -5.0f, 5.0f)
				);*/
		//Debug.Log ("Trigger Hit");
		/*if (movements.getEngaged()) {
			Vector2 movement = new Vector3 (moveHorizontal, moveVertical);
			GetComponent<Rigidbody2D> ().velocity = movement * speed;
		}*/
	}

	void OnCollisionExit2D(Collision2D  other) {
		//movementScript.collision = false;
		//Debug.Log ("Left: " + other.gameObject.tag);
	}
}
