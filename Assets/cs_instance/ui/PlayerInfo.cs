using UnityEngine;
using System;
using System.IO;
//using System.Globalization;

public class PlayerInfo : MonoBehaviour {

    public string stringToEdit;
    // Use this for initialization
    void Start () {
        stringToEdit = "Enter your name";
    }

    void OnGUI()
    {
        stringToEdit = GUI.TextField(new Rect(150, 50, 200, 25), stringToEdit, 25);
        if (GUI.Button(new Rect(200, 100, 150, 50), "Begin Adventure"))
        {
            print("Begin clicked");
            //create Folder   
            if (!Directory.Exists("Assets/cs_instance/SaveFiles"))
            {
                Directory.CreateDirectory("Assets/cs_instance/SaveFiles");
            }

            System.IO.File.WriteAllText("Assets/cs_instance/SaveFiles/Save.txt", stringToEdit + "," + DateTime.Now.ToString());
            Application.LoadLevel(3);
        }
        //Application.LoadLevel(2);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
