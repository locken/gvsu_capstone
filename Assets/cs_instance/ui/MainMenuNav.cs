using UnityEngine;
using System.Collections;

public class MainMenuNav : MonoBehaviour {
    public string stringToEdit;
    int screenW = Screen.width;
    int screenH = Screen.height;
    // Use this for initialization
    void Start () {
	
	}
    
    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(screenW / 3, screenH / 20, screenW / 2, screenH / 10), "<NULL> Object 'Name' not found");
        GUI.contentColor = Color.white;
        if (GUI.Button(new Rect(screenW / 3, screenH / 9, screenW / 4, screenH / 14), "Start New"))
        {
            //print("Start clicked");
            Application.LoadLevel(2);
        }
        if (GUI.Button(new Rect(screenW / 3, screenH / 4, screenW / 4, screenH / 14), "Load"))
        {

            //print("Start clicked");
            Application.LoadLevel(3);
        }
        if (GUI.Button(new Rect(screenW / 3, screenH / 3, screenW / 4, screenH / 14), "Options"))
        {
            //print("Start clicked");
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(screenW / 3, screenH / 2, screenW / 4, screenH / 14), "Exit"))
        {
            //print("Start clicked");
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
