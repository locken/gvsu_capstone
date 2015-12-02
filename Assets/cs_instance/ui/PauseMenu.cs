using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class PauseMenu : MonoBehaviour {
    bool paused, p_Pressed, afterStart;
    GameObject localMaster, localPlayer;
    // Use this for initialization
    void Start () {
        paused = p_Pressed = false;
        afterStart = true;
        localMaster = GameObject.Find("_Master");
    }

    public void PauseGame(bool val)
    {
        Time.timeScale = 0;
        paused = true;
        p_Pressed = val;
    }

    public bool GetPauseStatus()
    {
        return paused;
    } 
    
    public bool Get_P_Pressed()
    {
        return p_Pressed;
    }

    void OnGUI()
    {
        if (paused && p_Pressed && !localMaster.GetComponent<InventoryMenu>().GetInventoryStatus())
        {
            if (GUI.Button(new Rect(200, 100, 80, 50), "Unpause"))
            {
                //print("Unpause clicked");
                UnPauseGame();
            }
            if (GUI.Button(new Rect(200, 150, 80, 50), "Save Game"))
            {
                string path = "Assets/Resources/SaveFiles/Save.txt";
                //create Folder   
                if (!Directory.Exists("Assets/Resources/SaveFiles"))
                {
                    Directory.CreateDirectory("Assets/Resources/SaveFiles");
                }
                string stringToEdit = localPlayer.GetComponent<Attributes>().CharName;
                System.IO.File.WriteAllText(path, stringToEdit + "\n" + DateTime.Now.ToString() + "\n");
                System.IO.File.AppendAllText(path, "Level: " + localPlayer.GetComponent<Attributes>().Level.ToString() + "\n");
                System.IO.File.AppendAllText(path, "Health: " + localPlayer.GetComponent<Attributes>().Health.ToString() + "\n");
                System.IO.File.AppendAllText(path, "XP: " + localPlayer.GetComponent<Attributes>().XP.ToString() + "\n");
                System.IO.File.AppendAllText(path, "Active Weapon: basic_sword\n");
                System.IO.File.AppendAllText(path, "Inventory: \n basic_sword \n empty \n empty \n empty \n empty");
                //print("Save clicked");

            }
            if (GUI.Button(new Rect(200, 200, 80, 50), "Main Menu"))
            {
                //print("Main Menu clicked");
                UnPauseGame();
                Application.LoadLevel(0);
            }
        }
    }



    public void UnPauseGame()
    {
        Time.timeScale = 1;
        paused = p_Pressed = false;
        localMaster.GetComponent<HUD>().CyclePlaying();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("p") && !localMaster.GetComponent<InventoryMenu>().GetInventoryStatus())
        {
            PauseGame(true);
            localMaster.GetComponent<HUD>().CyclePlaying();
        }
        if (afterStart)
        {
            afterStart = false;
            localPlayer = GameObject.Find("Player");
        }
	}
}
