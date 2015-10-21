using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    private GameObject plyr;
    private SpriteRenderer playerSprite;
    private Object[] plyrSprt;
    private BoxCollider2D playerBody;

	// Use this for initialization
	void Start () {
        plyr = new GameObject();
        plyr.AddComponent<Playable>();
        plyr.AddComponent<movement>();
        plyrSprt = Resources.LoadAll("pc");
        playerSprite = plyr.AddComponent<SpriteRenderer>();
        playerSprite.sprite = (Sprite)plyrSprt[1];
        playerBody = plyr.AddComponent<BoxCollider2D>();
        plyr.AddComponent<weaponItem>();
        plyr.GetComponent("weaponItem").transform.position = new Vector3(14 / 24, 12 / 24, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
