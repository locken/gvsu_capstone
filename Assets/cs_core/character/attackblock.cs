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

        if (Input.GetKeyDown(KeyCode.Space)&&!Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetTrigger("Attack");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Block", true);
        }
        else
            anim.SetBool("Block", false);
	}
}
