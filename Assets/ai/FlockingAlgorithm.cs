using UnityEngine;
using System.Collections;

public class FlockingAlgorithm : MonoBehaviour {
	public float seperation;
	public float alignnment; 
	public float cohesion; 
	public static bool collision;
	public static float x;
	public static float y;

	void Start()
	{
		CircleCollider2D collider = GetComponent<CircleCollider2D> ();
		collider.radius = seperation;
	}

	void OnTriggerEnter2D(Collider2D  other) {
		movements.collision = true;
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

	void OnTriggerExit2D(Collider2D  other) {
		movements.collision = false;
	}
}
