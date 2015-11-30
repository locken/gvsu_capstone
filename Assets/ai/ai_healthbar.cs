using UnityEngine;
using System.Collections;

public class ai_healthbar : MonoBehaviour {

    GameObject ai_health;
    int screenW = Screen.width;
    int screenH = Screen.height;
    GameObject localMaster;
    bool playing;
    private GUIStyle currentStyle = new GUIStyle();
    Texture2D hudTexture, healthTexture, magicTexture;

    // Use this for initialization
    void Start()
    {
        playing = true;
        localMaster = GameObject.Find("_Master");
        healthTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        // set the pixel values

        healthTexture.SetPixel(0, 0, new Color(1f, 0f, 0f));

        // Apply all SetPixel calls
        healthTexture.Apply();
    }

    void OnGUI()
    {
        if (playing)
        {
            //GUI.contentColor = Color.blue;
            currentStyle.normal.background = hudTexture;
            //GUI.contentColor = Color.black;
            GUI.contentColor = Color.red;
            currentStyle.normal.background = healthTexture;
            GUI.Box(new Rect(0, 0, 1, 2/24), "", currentStyle);
        }
    }

    public void CyclePlaying()
    {
        playing = !playing;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
