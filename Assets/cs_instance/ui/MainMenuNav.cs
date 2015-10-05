using UnityEngine;
using System.Collections;

public class MainMenuNav : MonoBehaviour {
    public string stringToEdit;
    // Use this for initialization
    void Start () {
	
	}
    public void StartTheGame()
    {
        GetPlayerInfo();
        Application.LoadLevel(2);
    }
    public void GetPlayerInfo()
    {
        //stringToEdit = "Hello World";
        //private void OnGUI()
        //{
         //   stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
        //}
    }
    public void OptionsMenu()
    {
        Application.LoadLevel(1);
    }
    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
	
	}
}
