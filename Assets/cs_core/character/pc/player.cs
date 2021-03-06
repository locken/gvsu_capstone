﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public Object []spriteHolder;
    //player variables
    public GameObject plyr;
    public SpriteRenderer playerSprite;
    public BoxCollider2D playerCollider;
    public Attributes plyrStats;
    public PlayerInventory inv;

    //right hand variables
    public GameObject rightHand;
    public weaponItem rightHandItem;
    public SpriteRenderer rightSr;
    public BoxCollider2D rightBc;

    /*//left hand variables
    public GameObject leftHand;
    public Item leftHandItem;
    public SpriteRenderer leftSr;
    public BoxCollider2D leftBc;*/

    //used for hitting enemies
    //public ArrayList enemiesHit;
	public Rigidbody2D plyrRb; 
    private bool attack = false;
    private float wpnz = 0;
    private float wpnx = 18 / 24f;


    // Use this for initialization
    void Start()
    {

        //create player
        plyr = new GameObject();
        this.transform.parent = plyr.transform;
        plyr.name = "Player";
        plyr.tag = "Player";
        plyrStats = plyr.AddComponent<Attributes>();
        plyr.AddComponent<playermovement>();
        playerSprite = plyr.AddComponent<SpriteRenderer>();
        spriteHolder = Resources.LoadAll("pc");
        playerSprite.sprite = (Sprite)spriteHolder[1];
        playerCollider = plyr.AddComponent<BoxCollider2D>();
        playerCollider.transform.parent = plyr.transform;
        plyrRb = plyr.AddComponent<Rigidbody2D>();
        plyr.transform.localPosition = new Vector3(0, 0, -1);
        plyrRb.gravityScale = 0;
        plyrRb.isKinematic = false;
        plyrRb.drag = 10;
        plyr.AddComponent<Fireball>();
        plyr.AddComponent<Heal>();

        //need to set items colliders as triggers and give them an OnTriggerEnter2D that checks for Player tag
        //and adds itself to inventory if true.
        inv = plyr.AddComponent<PlayerInventory>();
        GameObject localMaster = GameObject.Find("Main Camera");
        //localMaster.AddComponent<CameraMovement>();
        localMaster.GetComponent<CameraMovement>().SetPlayer(plyr);


        //add rightHand to player
        rightHand = new GameObject();
        rightHand.name = "Right Hand";
        rightHand.tag = "Player";
        rightHand.transform.parent = plyr.transform;
        rightHandItem = rightHand.AddComponent<basic_sword>();
        rightSr = rightHand.AddComponent<SpriteRenderer>();

        spriteHolder = Resources.LoadAll("item/weapon");
        rightSr.sprite = (Sprite)spriteHolder[1];

        //rightSr.sprite = (Sprite)Resources.LoadAll("item/weapon")[0];

        rightHand.transform.localPosition = new Vector3(18 / 24f, 18 / 24f, 0);
        rightHand.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, wpnz), Vector3.up);
        rightBc = rightHand.AddComponent<BoxCollider2D>();
        rightBc.isTrigger = true;

        rightHand.AddComponent<damage>();
        rightHand.SendMessage("setWeapon", rightHandItem);
        rightHand.SetActive(false);

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
        //enemiesHit = new ArrayList();
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
            if (wpnz < 15)
            {
                wpnz++;
                for (int i = 0; i < 10; i++)
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
                rightHand.SendMessage("ClearArray");
                rightHand.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            plyr.GetComponent<Fireball>().cast();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            plyr.GetComponent<Heal>().cast();
        }
    }
}
