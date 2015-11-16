using UnityEngine;
using System;
using System.IO;

public class InventoryMenu : MonoBehaviour {
    bool inventory;
    GameObject localMaster;
    string dataRaw, activeWeapon, path;
    string playerName;
    string [] items, data;
    Texture activeTexture;
	// Use this for initialization

    public string getName()
    {
        return playerName;
    }
	void Start () {
        inventory = false;
        localMaster = GameObject.Find("_Master");
        items = new string[10];
        path = "Assets/Resources/SaveFiles/Save.txt";
        if (File.Exists(path)){
            dataRaw = File.ReadAllText(path);
            data = dataRaw.Split(new string[] { "\n" }, StringSplitOptions.None);
            playerName = data[0];
            activeWeapon = data[5].Substring(15);
            if (activeWeapon.Trim().Equals("basic_sword"))
            {
                activeTexture = Resources.Load<Texture>("item/weapon/basic_sword");
            } else if (activeWeapon.Trim().Equals("dagger"))
            {
                activeTexture = Resources.Load<Texture>("item/weapon/dagger");
            } else
            {
                Debug.Log("weapon name not found");
            }
        }
        else //Default values for the inventory
        {
            Debug.Log("File not found");
            playerName = "No Name Nancy";
            activeWeapon = "basic_sword";
            items[0] = "basic_sword";
        }
    }
	
    void ShowInventory()
    {
        localMaster.GetComponent<HUD>().CyclePlaying();
        localMaster.GetComponent<PauseMenu>().PauseGame(false);
    }

    public void AddItem(string newItem)
    {
        if (FreeItemSpot())
        {
            Debug.Log("There is a free spot");
        }
    }

    bool FreeItemSpot()
    {
        int i = 7;
        while (!data[i].Equals("empty"))
        {
            if(i < 11)
            {
                i++;
            } else
            {
                if (data[i].Equals("empty")) //'i' == 11 here.
                {
                    i++; //Now 'i' should be greater than 11.
                }
                break;
            }
        }
        if(i < 12)
        {
            return true;
        }
        return false;
    }

    public bool GetInventoryStatus()
    {
        return inventory;
    }

    void OnGUI()
    {
        if (localMaster.GetComponent<PauseMenu>().GetPauseStatus() && inventory && !localMaster.GetComponent<PauseMenu>().Get_P_Pressed())
        {
            GUI.Box(new Rect(10, 10, 400, 400), playerName + "'s Inventory");
            GUI.Label(new Rect(20, 40, 200, 20), "Active Weapon:");
            GUI.Label(new Rect(120, 40, 200, 20), activeWeapon);
            GUI.DrawTexture(new Rect(200, 30, 70, 40), activeTexture);
            GUI.Label(new Rect(20, 80, 200, 20), "All Items:");
            GUI.Label(new Rect(20, 100, 200, 20), "Item 1:");
            GUI.Label(new Rect(60, 100, 200, 20), data[7]);
            GUI.Label(new Rect(20, 120, 200, 20), "Item 2:");
            GUI.Label(new Rect(60, 120, 200, 20), data[8]);
            GUI.Label(new Rect(20, 140, 200, 20), "Item 3:");
            GUI.Label(new Rect(60, 140, 200, 20), data[9]);
            GUI.Label(new Rect(20, 160, 200, 20), "Item 4:");
            GUI.Label(new Rect(60, 160, 200, 20), data[10]);
            GUI.Label(new Rect(20, 180, 200, 20), "Item 5:");
            GUI.Label(new Rect(60, 180, 200, 20), data[11]);
            if (GUI.Button(new Rect(160, 360, 120, 40), "Return to game"))
            {
                print("Unpause clicked");
                inventory = false;
                localMaster.GetComponent<PauseMenu>().UnPauseGame();
            }
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("i") && !localMaster.GetComponent<PauseMenu>().Get_P_Pressed())
        {
            inventory = true;
            ShowInventory();
        }
    }
}
