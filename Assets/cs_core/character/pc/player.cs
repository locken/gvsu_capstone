﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    //player variables
    public GameObject plyr;
    public SpriteRenderer playerSprite;
    public BoxCollider2D playerCollider;

    //right hand variables
    public GameObject rightHand;
    public Item rightHandItem;
    public SpriteRenderer rightSr;
    public BoxCollider2D rightBc;

    /*//left hand variables
    public GameObject leftHand;
    public Item leftHandItem;
    public SpriteRenderer leftSr;
    public BoxCollider2D leftBc;*/

    //array used to keep track of objects hit during one swing
    public ArrayList enemiesHit;

    private bool attack = false;
    private float wpnz = 0;
    private float wpnx = 18 / 24f;
    

	// Use this for initialization
	void Start () {

        //create player
        plyr = new GameObject();
        plyr.name = "Player";
        plyr.AddComponent<Playable>();
        plyr.AddComponent<movement>();
        playerSprite = plyr.AddComponent<SpriteRenderer>();
        playerSprite.sprite = (Sprite)Resources.LoadAll("pc")[1];
        playerCollider = plyr.AddComponent<BoxCollider2D>();

        //add rightHand to player
        rightHand = new GameObject();
        rightHand.name = "Right Hand";
        rightHand.transform.parent = plyr.transform;
        rightHandItem = rightHand.AddComponent<basic_sword>();
        rightSr = rightHand.AddComponent<SpriteRenderer>();
        rightSr.sprite = (Sprite)Resources.LoadAll("item/weapon")[1];
        rightHand.transform.localPosition = new Vector3(18 / 24f, 18 / 24f, 0);
        rightHand.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, wpnz), Vector3.up);
        rightHand.SetActive(false);
        rightBc = rightHand.AddComponent<BoxCollider2D>();
        rightBc.isTrigger = true;

        /*//add leftHand to player
        rightHand = new GameObject();
        rightHand.name = "Right Hand";
        rightHand.transform.parent = plyr.transform;
        handItem = rightHand.AddComponent<basic_sword>();
        wpn = rightHand.AddComponent<SpriteRenderer>();
        wpn.sprite = (Sprite)Resources.LoadAll("item/weapon")[2];
        rightHand.transform.localPosition = new Vector3(-18 / 24f, 18 / 24f, 0);
        rightHand.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, wpnz), Vector3.up);
        rightHand.SetActive(false);
        rightHand.AddComponent<BoxCollider2D>();*/

        //instantiate enemiesHit
        enemiesHit = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            attack = true;
            rightHand.SetActive(true);
        }
        /*might need to add bool attacked/damaged to enemy class.  use an array list in weapon object to hold all enemy gameobjects attacked, at end of attack cycle
        loop through list and set all enemy bools to false.  could fix multiple damage deductions from one attack cycle(enemy has health deducted base on x degrees, since
        attack rotates 1 degree at a time).*/
        if (attack)
        {
            if (wpnz < 10)
            {
                wpnz++;
                for (int i = 0; i < 15; i++)
                {
                    rightHand.transform.Rotate(0, 0, 1);
                    wpnx = wpnx - ((2 / 3f) / 150f);
                    rightHand.transform.localPosition = new Vector3(wpnx, 18/24f, 0f);
                }
            }
            else
            {
                wpnz = 0;
                rightHand.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, wpnz), Vector3.up);
                wpnx = 18 / 24f;
                rightHand.transform.localPosition = new Vector3(wpnx, 18 / 24f, 0f);
                attack = false;
                enemiesHit.Clear();
                rightHand.SetActive(false);
            }
        }

    }

    void onTriggerEnter(Collider other)
    {

    }
}
