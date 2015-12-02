using UnityEngine;
using System.Collections;

public class attackblock : MonoBehaviour {

    Animator anim;
    Quaternion rot;
	bool collided; 
	Collider2D currentEnemy;

	void OnTriggerEnter2D(Collider2D other)
    {
		collided = true;
		currentEnemy = other;
    }

	void OnTriggerExit2D(Collider2D other)
	{
		collided = false;
		currentEnemy = other;
	}

    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)&&!Input.GetKey(KeyCode.LeftShift))
        {
			try{
            anim.SetTrigger("Attack");
			//if (other.tag == "Enemy") {
			if(collided){
				Attributes enemyAttributes = currentEnemy.gameObject.GetComponent<Attributes>();
				enemyAttributes.Health -= 10;
				Debug.Log(currentEnemy.name + ": " + enemyAttributes.Health);
				}
			} catch(MissingReferenceException ex){

			}
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
