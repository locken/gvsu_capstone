using UnityEngine;
using System.Collections;

public class AbilityCasted : MonoBehaviour {

    public int damage;
    public string id, target;
    Vector2 movementVector;

    public void setStats(int d, string name,float x, float y, Quaternion rot,string t)
    {
        damage = d;
        id = name;
        movementVector = new Vector2();
        movementVector.x = x;
        movementVector.y = y;
        transform.rotation = rot;
        target = t;
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
        if (other.gameObject.CompareTag (target)) {
            Attributes enemy;
            if (other.gameObject.name == "Right Hand")
                enemy = other.gameObject.GetComponentInParent<Attributes>();
            else
                enemy = other.gameObject.GetComponent<Attributes>();
			int health = enemy.Health;
			enemy.Health = health - damage;
			Debug.Log (enemy.gameObject.name + " health: " + enemy.Health);
		}
		if (!other.gameObject.CompareTag(gameObject.tag))
        {
            Destroy(this.gameObject);
        }
    }
}
