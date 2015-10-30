using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour {
    float musicSlider, gameSoundSlider;
    bool muteAll, resetOnce;

    // Use this for initialization
    void Start () {
        muteAll = resetOnce = false;
        musicSlider = gameSoundSlider = 2.0f;
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(200, 100, 80, 50), "Back"))
        {
            print("Back clicked");
            Application.LoadLevel(0);
        }
        if (GUI.Button(new Rect(200, 150, 80, 50), "Load Game"))
        {
            print("Load clicked");
            
        }
        GUI.Label(new Rect(200, 200, 100, 20), "Sound Options");
        GUI.Label(new Rect(200, 220, 100, 20), "Music");
        musicSlider = GUI.HorizontalSlider(new Rect(200, 240, 100, 20), musicSlider, 0.0f, 4.0f);
        GUI.Label(new Rect(200, 260, 100, 20),"Game Sounds");
        gameSoundSlider = GUI.HorizontalSlider(new Rect(200, 280, 100, 20), gameSoundSlider, 0.0f, 4.0f);
        GUI.Label(new Rect(200, 300, 100, 20), "Mute All");
        muteAll = GUI.Toggle(new Rect(200, 320, 100, 20), muteAll, new GUIContent());
        if (muteAll)
        {
            Debug.Log("Mute all clicked"); 
            musicSlider = 0.0f;
            gameSoundSlider = 0.0f;
            resetOnce = false;
        } else if (!muteAll)
        {
            Debug.Log("uncheck Mute all clicked");
            if (!resetOnce)
            {
                musicSlider = 2.0f;
                gameSoundSlider = 2.0f;
                resetOnce = true;
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
