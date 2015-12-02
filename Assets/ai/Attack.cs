using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public int damage;
	public float attackDelay;
	public int count; 
	public Animator anim;
	public bool attacking; 
	public GameObject rightHand;
	// Use this for initialization
	void Start () {
		attackDelay = 2.0f;
		count = 0;
		anim = new Animator ();
		attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		Transform target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
		if (GetComponent<movements>().playerCollision && Vector3.Distance (this.transform.position, target.position) < 2f) {
			//anim.SetTrigger ("Attack");
			Debug.Log("ATTACKING");
			attacking = true;
		} else {
			attacking = false;
		}
	
	/*Debug.Log ("Player Movement: " + GetComponent<movements> ().playerCollision);
		if (GetComponent<movements>().playerCollision && attackDelay < Time.time) {
			attackDelay = Time.time + Random.Range (2.0f, 3.0f);
			GetComponent<Playable>().Health -= damage;
			Debug.Log(gameObject.name + ": " + GetComponent<Playable>().Health);
		}*/
	}

}