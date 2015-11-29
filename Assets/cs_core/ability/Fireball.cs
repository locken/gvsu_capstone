using UnityEngine;
using System.Collections;


public class Fireball : Ability
{

    public int damage;

    void Start()
    {
        id = "fireball";
        damage = 15;
    }

    public override bool cast()
    {
        GameObject obj = new GameObject();
        obj.name = "Fireball";
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
        int direction = gameObject.GetComponent<movement>().direction;
        float x = 0, y = 1;
        if(direction == 1)
        {
            y = 1;
            x = 0;
            rot = Quaternion.LookRotation(new Vector3(0, 0,270), Vector3.left);
        }
        else if(direction == 2)
        {
            y = 0;
            x = -1;
            rot = Quaternion.LookRotation(new Vector3(0, 0, 180), Vector3.down);
        }
        else if(direction == 3)
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
        temp.setStats(damage, id, x, y, rot);
        //temp.setStart(gameObject.transform.position.x, gameObject.transform.position.y + 1);
        //set cooldown
        return true;
    }

    void Update()
    {
        
    }
}