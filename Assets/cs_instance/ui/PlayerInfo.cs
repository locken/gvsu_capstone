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
            string path = "Assets/Resources/SaveFiles/Save.txt";
            print("Begin clicked");
            //create Folder   
            if (!Directory.Exists("Assets/cs_instance/SaveFiles"))
            {
                Directory.CreateDirectory("Assets/cs_instance/SaveFiles");
            }

            System.IO.File.WriteAllText(path, stringToEdit + "\n" + DateTime.Now.ToString() + "\n");
            System.IO.File.AppendAllText(path, "Level: 1\n");
            System.IO.File.AppendAllText(path, "Health: 100\n");
            System.IO.File.AppendAllText(path, "Magic: 50\n");
            System.IO.File.AppendAllText(path, "Active Weapon: basic_sword\n");
            System.IO.File.AppendAllText(path, "Inventory: \n basic_sword \n empty \n empty \n empty \n empty");
            Application.LoadLevel(3);
        }
        //Application.LoadLevel(2);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
