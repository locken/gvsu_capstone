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
        Debug.Log("attack");
        if (!enemiesHit.Contains(other.gameObject))
        {
            Debug.Log("object not hit");
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("object is enemy");
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
        Debug.Log("weapon damage: " + rightHandItem.weaponDamage);
        Debug.Log("AI current Health: " + enemy.Health);
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
