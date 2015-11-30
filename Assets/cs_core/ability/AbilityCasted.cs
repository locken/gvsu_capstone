using UnityEngine;
using System.Collections;

public class AbilityCasted : MonoBehaviour {

    public int damage;
    public string id;
    Vector2 movementVector;

    public void setStats(int d, string name,float x, float y, Quaternion rot)
    {
        damage = d;
        id = name;
        movementVector = new Vector2();
        movementVector.x = x;
        movementVector.y = y;
        transform.rotation = rot;
    }

    public void setStart(GameObject other)
    {
        gameObject.transform.position = other.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(movementVector * 60, ForceMode2D.Force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            AI_Attributes enemy = other.gameObject.GetComponent("AI_Attributes") as AI_Attributes;
            int health = enemy.Health;
            Debug.Log(health);
            enemy.Health = health - damage;
            Debug.Log(other.gameObject.name + " health: " + enemy.Health);
        }
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
