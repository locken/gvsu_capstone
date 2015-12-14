using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public int damage;
	public float attackDelay;
	public int count; 
	public Animator anim;
	public bool attacking, attack; 
	public GameObject rightHand;
    float wpnz, wpnx;
	// Use this for initialization
	void Start () {
		attackDelay = 2.0f;
		count = 0;
		anim = new Animator ();
		attacking = false;
        wpnz = 0;
        wpnx = 18 / 24f;
        attack = false;
	}

    // Update is called once per frame
    void Update()
    {
        Transform target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        if (GetComponent<movements>().playerCollision && Vector3.Distance(this.transform.position, target.position) < 2f)
        {
            //anim.SetTrigger ("Attack");
            Debug.Log("ATTACKING");
            attacking = true;
        }
        else
        {
            attacking = false;
        }

        /*if (Vector3.Distance(gameObject.transform.position, target.position) < 2f)
        {
            attack = true;
            rightHand.SetActive(true);
        }*/
        if (attack)
        {
            if (wpnz < 15)
            {
                wpnz++;
                for (int i = 0; i < 10; i++)
                {
                    rightHand.transform.Rotate(0, 0, 1);
                    wpnx = wpnx - ((2 / 3f) / 150f);
                    rightHand.transform.localPosition = new Vector3(wpnx, 18 / 24f, 0f);
                }

            }
            else
            {
                wpnz = 0;
                rightHand.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, wpnz), Vector3.up);
                wpnx = 18 / 24f;
                rightHand.transform.localPosition = new Vector3(wpnx, 18 / 24f, 0f);
                //rightHand.SendMessage ("ClearArray");
                rightHand.SetActive(false);
                attack = false;
                GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Attributes>().Health--;

                Debug.Log("player health: " + GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Attributes>().Health);
            }

            /*Debug.Log ("Player Movement: " + GetComponent<movements> ().playerCollision);
                if (GetComponent<movements>().playerCollision && attackDelay < Time.time) {
                    attackDelay = Time.time + Random.Range (2.0f, 3.0f);
                    GetComponent<Playable>().Health -= damage;
                    Debug.Log(gameObject.name + ": " + GetComponent<Playable>().Health);
                }*/
        }
    }

}