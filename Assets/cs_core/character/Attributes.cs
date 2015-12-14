using UnityEngine;
using System.Collections;
using System;

public class Attributes : Character {

	/*Local variables accessable only from
	get set methods*/
	private int m_level, m_health, m_xp, m_magic;
	private float m_speed;
	private string m_charName;
    public string skill_name;
    GameObject localHUD;
    GameObject localMaster, localPlayer;
    private bool afterStart;
    private float timestamp;

    public bool Engaged
    {
        get
        {
            return Engaged;
        }
        set
        {
            Engaged = value;
        }
    }

    public override int Level{
		get{
			return m_level;
		}
		set{
			m_level = value;
		}
	}

    public override int Magic
    {
        get
        {
            return m_magic;
        }

        set
        {
            m_magic = value;
        }
    }

    public override int Health{
		get{
			return m_health;
		}
		set{
			m_health = value;
            if (this.tag == "Player" && m_health < (m_health + value))
            {
                GameObject.Find("_Master").GetComponent<HUD>().DecreaseHealthBar();
            }
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
        afterStart = true;
		m_level = 1;
		m_health = 100;
        m_magic = 100;
        m_xp = 0;
        localHUD = GameObject.Find("_Master");
        abilities = new ArrayList();
        GameObject go = new GameObject();
        Ability f = (Ability)go.AddComponent<Fireball>();// go.AddComponent<Fireball>();
        if(gameObject.tag == "Enemy")
        {
            localMaster = GameObject.Find("_Master");
            localMaster.GetComponent<HUD>().IncrementEnemy();
        }
       
        
        //go.destroy();
	}

	// Update is called once per frame
	void Update () {
        if (gameObject.tag == "Player")
        {
            if (m_xp > 99)
            {
                m_level++;
                m_xp = m_xp % 100;
            }
            if (m_health < 1)
            {
                //Debug.Log("Game Over");
                localHUD.GetComponent<HUD>().CycleGameOver();

            }
        }
        else
        {
            if (m_health <= 0)
            {
                localMaster.GetComponent<HUD>().DecrementEnemy();
                localPlayer.GetComponent<Attributes>().XP += 10;
                Destroy(this.gameObject);
            }
            if (afterStart)
            {
                afterStart = false;
                localPlayer = GameObject.Find("Player");
            }
        }
        if (timestamp < Time.time)
        {
            if (Health < 100)
            {
                
                GameObject.Find("_Master").GetComponent<HUD>().IncreaseHealthBar();
                Health++;
               // if (gameObject.tag == "Player")
               // {
                    //GameObject.Find("_Master").GetComponent<HUD>().IncreaseHealthBar();
                
                //}
            }
            if (Magic < 100)
            {
                if (Magic + 2 > 100)
                    Magic = 100;
                else
                    Magic = Magic + 2;
            }
            timestamp = Time.time + 1;
        }

	}
}
