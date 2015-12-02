using UnityEngine;
using System.Collections;

public class Heal : Ability {

	// Use this for initialization
    public int damage;
    private float timestamp;
    Attributes self;

    void Start()
    {
        id = "Heal";
        damage = 50;
        cooldown = 20;
        magiccost = 60;
        self = gameObject.GetComponent<Attributes>();
    }

    public override bool cast()
    {
        if (magiccost < gameObject.GetComponent<Attributes>().Magic)
        {
            if (Time.time > timestamp)
            {
                if (self.Health + damage > 100)
                    self.Health = 100;
                else
                    self.Health = self.Health + damage;
                timestamp = Time.time + cooldown;
                return true;
            }
        }
        return false;
	}
}
