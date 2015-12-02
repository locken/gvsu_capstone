using UnityEngine;
using System.Collections;


public class Fireball : Ability
{

    public int damage;
    private float timestamp;

    void Start()
    {
        id = "fireball";
        damage = 15;
        cooldown = 5;
        magiccost = 20;
        origin = gameObject.tag;
        if (origin.Equals("Player"))
            target = "Enemy";
        else
            target = "Player";
    }

    public override bool cast()
    {
        if (magiccost < gameObject.GetComponent<Attributes>().Magic)
        {
            if (Time.time > timestamp)
            {
                GameObject obj = new GameObject();
                obj.name = "Fireball";
                obj.tag = origin;
                AbilityCasted temp = obj.AddComponent<AbilityCasted>();
                SpriteRenderer sr = obj.AddComponent<SpriteRenderer>();
                sr.sprite = Resources.Load<Sprite>("ability/fireball");
                Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0;
                rb.isKinematic = false;
                rb.drag = 10;
                CircleCollider2D cc = obj.AddComponent<CircleCollider2D>();
                cc.isTrigger = true;
                Quaternion rot;
                int direction;
                if (gameObject.tag == "Player")
                {
                    direction = gameObject.GetComponent<playermovement>().direction;
                }
                else
                {
                    direction = 1;
                }
                float x = 0, y = 1;
                if (direction == 1)
                {
                    y = 1;
                    x = 0;
                    rot = Quaternion.LookRotation(new Vector3(0, 0, 270), Vector3.left);
                }
                else if (direction == 2)
                {
                    y = 0;
                    x = -1;
                    rot = Quaternion.LookRotation(new Vector3(0, 0, 180), Vector3.down);
                }
                else if (direction == 3)
                {
                    y = -1;
                    x = 0;
                    rot = Quaternion.LookRotation(new Vector3(0, 0, 90), Vector3.right);
                }
                else
                {
                    y = 0;
                    x = 1;
                    rot = Quaternion.LookRotation(new Vector3(0, 0, 0), Vector3.up);
                }

                //put stuff for ai rotation here


                temp.setStats(damage, id, x, y, rot,target);
                temp.setStart(gameObject);
                timestamp = Time.time + cooldown;
                gameObject.GetComponent<Attributes>().Magic = gameObject.GetComponent<Attributes>().Magic - magiccost;
                //set cooldown
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        
    }
}