using UnityEngine;
using System.Collections;

public class damage : MonoBehaviour {

    public ArrayList enemiesHit;
    public weaponItem rightHandItem;

	void Start()
    {
        enemiesHit = new ArrayList();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (!enemiesHit.Contains(other.gameObject))
        {
			if (other.gameObject.CompareTag("Enemy"))
            {
                ApplyDamage(other);
            }
        }
    }

    void ApplyDamage(Collider2D other)
    {
        AI_Attributes enemy = other.gameObject.GetComponent("AI_Attributes") as AI_Attributes;
        int health = enemy.Health;
        Debug.Log(health);
        enemiesHit.Add(other.gameObject);
        enemy.Health = health - rightHandItem.weaponDamage;
        Debug.Log(other.gameObject.name + " health: " + enemy.Health);
    }

    void ClearArray()
    {
        enemiesHit.Clear();
    }

    void setWeapon(weaponItem weapon)
    {
        rightHandItem = weapon;
        Debug.Log("weapon set");
    }
}
