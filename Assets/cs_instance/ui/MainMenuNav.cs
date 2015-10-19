using UnityEngine;
using System.Collections;

public class MainMenuNav : MonoBehaviour {
    public string stringToEdit;
    // Use this for initialization
    void Start () {
	
	}
    
    void OnGUI()
    {
        if (GUI.Button(new Rect(185, 100, 80, 50), "Start New"))
        {
            print("Start clicked");
            Application.LoadLevel(3);
        }
        if (GUI.Button(new Rect(185, 150, 80, 50), "Options"))
        {
            print("Start clicked");
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(200, 200, 50, 50), "Exit"))
        {
            print("Start clicked");
            Application.Quit();
        }
    }


    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
