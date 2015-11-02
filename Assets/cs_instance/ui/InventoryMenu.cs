using UnityEngine;
using System.Collections;

public class InventoryMenu : MonoBehaviour {
    bool inventory;
    GameObject localPause;
	// Use this for initialization
	void Start () {
        inventory = false;
        localPause = GameObject.Find("_Master");
    }
	
    void ShowInventory()
    {
        localPause.GetComponent<PauseMenu>().PauseGame(false);
    }

    public bool GetInventoryStatus()
    {
        return inventory;
    }

    void OnGUI()
    {
        if (localPause.GetComponent<PauseMenu>().GetPauseStatus() && inventory && !localPause.GetComponent<PauseMenu>().Get_P_Pressed())
        {
            GUI.Box(new Rect(10, 10, 400, 400), "Player Inventory");
            if (GUI.Button(new Rect(160, 360, 120, 40), "Return to game"))
            {
                print("Unpause clicked");
                inventory = false;
                localPause.GetComponent<PauseMenu>().UnPauseGame();
            }
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("i") && !localPause.GetComponent<PauseMenu>().Get_P_Pressed())
        {
            inventory = true;
            ShowInventory();
        }
    }
}
