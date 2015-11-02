using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    bool paused, p_Pressed;
    GameObject localInventory;
    // Use this for initialization
    void Start () {
        paused = p_Pressed = false;
        localInventory = GameObject.Find("_Master");
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
        if (paused && p_Pressed && !localInventory.GetComponent<InventoryMenu>().GetInventoryStatus())
        {
            if (GUI.Button(new Rect(200, 100, 80, 50), "Unpause"))
            {
                print("Unpause clicked");
                UnPauseGame();
            }
            if (GUI.Button(new Rect(200, 150, 80, 50), "Save Game"))
            {
                print("Save clicked");

            }
            if (GUI.Button(new Rect(200, 200, 80, 50), "Main Menu"))
            {
                print("Main Menu clicked");
                UnPauseGame();
                Application.LoadLevel(0);
            }
        }
    }



    public void UnPauseGame()
    {
        Time.timeScale = 1;
        paused = p_Pressed = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("p") && !localInventory.GetComponent<InventoryMenu>().GetInventoryStatus())
        {
            PauseGame(true);
        }
	}
}
