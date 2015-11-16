using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
    int screenW = Screen.width;
    int screenH = Screen.height;
    GameObject localMaster;
    bool playing;
    // Use this for initialization
    void Start () {
        playing = true;
        localMaster = GameObject.Find("_Master");
    }

    void OnGUI()
    {
        if (playing)
        {
            GUI.Box(new Rect(0, 0, screenW / 3, screenH / 8), localMaster.GetComponent<InventoryMenu>().getName());
            GUI.Label(new Rect(5, screenH / 26, screenW / 10, screenH / 10), "Health:");
            GUI.Label(new Rect(5, screenH / 14, screenW / 10, screenH / 10), "Magic:");
        }
    }

    public void CyclePlaying()
    {
        playing = !playing;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
