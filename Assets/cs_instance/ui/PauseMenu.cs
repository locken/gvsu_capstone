using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    bool paused;
	// Use this for initialization
	void Start () {
        paused = false;
	}

    void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
    }

    void OnGUI()
    {
        if (paused)
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



    void UnPauseGame()
    {
        Time.timeScale = 1;
        paused = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("p"))
        {
            PauseGame();
        }
	}
}
