using UnityEngine;
using System.Collections;

public class damage : MonoBehaviour {

    public ArrayList enemiesHit;
    public weaponItem rightHandItem;
    private string target;

	void Start()
    {
        enemiesHit = new ArrayList();
        if (gameObject.CompareTag("Player"))
            target = "Enemy";
        else
            target = "Player";
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (!enemiesHit.Contains(other.gameObject))
        {
			if (other.gameObject.CompareTag(target))
            {
                Attributes enemy;
                if (other.gameObject.name.Equals("Right Hand"))
                    enemy = other.gameObject.GetComponentInParent<Attributes>();
                else
                    enemy = other.gameObject.GetComponent<Attributes>();
                int health = enemy.Health;
                enemiesHit.Add(other.gameObject);
                enemy.Health = health - rightHandItem.weaponDamage;
                Debug.Log(other.gameObject.name + " health: " + enemy.Health);
            }
        }
    }

    void ClearArray()
    {
        enemiesHit.Clear();
    }

    void setWeapon(weaponItem weapon)
    {
        rightHandItem = weapon;
    }
}
