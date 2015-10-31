using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public int damage;
	public float attackDelay;
	public int count; 
	// Use this for initialization
	void Start () {
		attackDelay = 2.0f;
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (AI_Attributes.Engaged && attackDelay < Time.time) {
			attackDelay = Time.time + Random.Range (2.0f, 3.0f);
			Playable -= damage;
			Debug.Log(gameObject.name + ": " + Playable.Health);
		}*/
	}
}
