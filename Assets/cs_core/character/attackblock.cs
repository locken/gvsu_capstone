using UnityEngine;
using System.Collections;

public class attackblock : MonoBehaviour {

    Animator anim;
    Quaternion rot;

	void OnTriggerEnter2D(Collider2D other)
    {
        Destroy (other.gameObject);
    }

    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }

        if (Input.GetMouseButton(1))
        {
            anim.SetBool("Block", true);
        }
        else
            anim.SetBool("Block", false);
	}
}
