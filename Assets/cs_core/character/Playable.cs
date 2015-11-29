using UnityEngine;
using System.Collections;

public class Playable : Character {

	/*Local variables accessable only from
	get set methods*/
	private int m_level, m_health, m_xp;
	private float m_speed;
	private string m_charName;
    public string skill_name;
    
	public override int Level{
		get{
			return m_level;
		}
		set{
			m_level = value;
		}
	}

	public override int Health{
		get{
			return m_health;
		}
		set{
			m_health = value;
		}
	}

	public override int XP{
		get{
			return m_xp;
		}
		set{
			m_xp = value;
		}
	}

	public override float Speed{
		get{
			return m_speed;
		}
		set{
			m_speed = value;
		}
	}

	public override string CharName{
		get{
			return m_charName;
		}
		set{
			m_charName = value;
		}
	}

    // Use this for initialization
    void Start () {
		m_level = 1;
		m_health = 100;

        abilities = new ArrayList();
        GameObject go = new GameObject();
        Ability f = (Ability)go.AddComponent<Fireball>();// go.AddComponent<Fireball>();
       
        
        //go.destroy();
        abilities.Add(f);
        Ability temp = (Ability)abilities[0];
        temp.cast();
        f.cast();
    
	}

	// Update is called once per frame
	void Update () {
	
	}
}
