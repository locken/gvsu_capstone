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

        //Ability keys

        if (Input.GetKey(KeyCode.R))
        {

        }

        if (Input.GetKey(KeyCode.F))
        {

        }

        if (Input.GetKey(KeyCode.C))
        {

        }

        //Select key

        if (Input.GetKey(KeyCode.Tab))
        {

        }

        //Interact key

        if (Input.GetKey(KeyCode.E))
        {

        }

        //Open inventory

        if (Input.GetKey(KeyCode.I))
        {

        }
    }
}
