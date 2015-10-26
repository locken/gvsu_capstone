using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public GameObject plyr;
    public GameObject plyrwpn;
    private weaponItem wpnitem;
    private SpriteRenderer wpn;
    private bool attack = false;
    private float wpnz = 0;
    private SpriteRenderer playerSprite;
    private BoxCollider2D playerBody;

	// Use this for initialization
	void Start () {
        plyr = new GameObject();
        plyr.AddComponent<Playable>();
        plyr.AddComponent<movement>();
        playerSprite = plyr.AddComponent<SpriteRenderer>();
        playerSprite.sprite = (Sprite)Resources.LoadAll("pc")[1];
        playerBody = plyr.AddComponent<BoxCollider2D>();
        plyr.AddComponent<weaponItem>();
        plyr.GetComponent("weaponItem").transform.position = new Vector3(14 / 24, 12 / 24, 0);

        //add weapon to player
        plyrwpn = new GameObject();
        plyrwpn.name = "Player Weapon";
        plyrwpn.transform.parent = plyr.transform;
        wpnitem = plyrwpn.AddComponent<basic_sword>();
        wpn = plyrwpn.AddComponent<SpriteRenderer>();
        wpn.sprite = (Sprite)Resources.LoadAll("item/weapon")[2];
        plyrwpn.transform.localPosition = new Vector3(18 / 24f, 18 / 24f, 0);
        plyrwpn.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, wpnz), Vector3.up);
        plyrwpn.SetActive(false);
        plyrwpn.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            attack = true;
            plyrwpn.SetActive(true);
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
                    plyrwpn.transform.Rotate(0, 0, 1);
                }
            }
            else
            {
                wpnz = 0;
                plyrwpn.transform.localRotation = Quaternion.LookRotation(new Vector3(0, 0, wpnz), Vector3.up);
                attack = false;
                plyrwpn.SetActive(false);
            }
        }

    }
}
