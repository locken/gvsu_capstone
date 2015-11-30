using UnityEngine;
using System;
using System.IO;

public class PlayerInfo : MonoBehaviour {

    public string stringToEdit;
    int screenW = Screen.width;
    int screenH = Screen.height;

    // Use this for initialization
    void Start () {
        stringToEdit = "Enter your name";
    }

    void StartNewGame()
    {
        string path = "Assets/Resources/SaveFiles/Save.txt";
        //create Folder   
        if (!Directory.Exists("Assets/Resources/SaveFiles"))
        {
            Directory.CreateDirectory("Assets/Resources/SaveFiles");
        }

        System.IO.File.WriteAllText(path, stringToEdit + "\n" + DateTime.Now.ToString() + "\n");
        System.IO.File.AppendAllText(path, "Level: 1\n");
        System.IO.File.AppendAllText(path, "Health: 100\n");
        System.IO.File.AppendAllText(path, "Magic: 50\n");
        System.IO.File.AppendAllText(path, "Active Weapon: basic_sword\n");
        System.IO.File.AppendAllText(path, "Inventory: \n basic_sword \n empty \n empty \n empty \n empty");
        Application.LoadLevel(3);
    }

    void OnGUI()
    {
        stringToEdit = GUI.TextField(new Rect(screenW / 4, (screenH - (screenH / 2)) / 5, screenW / 4, screenH / 18), stringToEdit, 25);
        Event e = Event.current;
        if (e.keyCode == KeyCode.Return)
        {
            StartNewGame();
        }
        if (GUI.Button(new Rect(screenW / 4, (screenH - (screenH / 2)) / 3, screenW / 4, screenH / 10), "Begin Adventure"))
        {
            StartNewGame();
        }
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(screenW / 5, (screenH - (screenH / 2)) / 2, screenW / 2, screenH / 10), "Controls:");
        GUI.Label(new Rect(screenW / 5, (screenH - (screenH / 3)) / 2, screenW / 2, screenH / 10), "Use w, s, a, d to face up, down, left right");
        GUI.Label(new Rect(screenW / 5, (screenH - (screenH / 4)) / 2, screenW / 2, screenH / 10), "Use arrow keys to move up, down, left right");
        GUI.Label(new Rect(screenW / 5, (screenH - (screenH / 7)) / 2, screenW / 2, screenH / 10), "Use 'f' to cast a fireball");
        GUI.Label(new Rect(screenW / 5, (screenH - (screenH / 23)) / 2, screenW / 2, screenH / 10), "Use the spacebar to swing your weapon");
        GUI.Label(new Rect(screenW / 5, (screenH + (screenH / 16)) / 2, screenW / 2, screenH / 10), "Use 'p' to pause");
        GUI.Label(new Rect(screenW / 5, (screenH + (screenH / 6)) / 2, screenW / 2, screenH / 10), "Use 'i' to view the inventory");
    }

    // Update is called once per frame
    void Update () {

	}
}
