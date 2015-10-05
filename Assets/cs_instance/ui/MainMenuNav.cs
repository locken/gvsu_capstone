using UnityEngine;
using System.Collections;

public class MainMenuNav : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public void StartTheGame()
    {
        Application.LoadLevel(2);
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
