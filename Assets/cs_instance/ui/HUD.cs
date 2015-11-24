using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
    int screenW = Screen.width;
    int screenH = Screen.height;
    GameObject localMaster;
    bool playing;
    private GUIStyle currentStyle = new GUIStyle();
    Texture2D hudTexture, healthTexture, magicTexture;

    // Use this for initialization
    void Start () {
        playing = true;
        localMaster = GameObject.Find("_Master");
        hudTexture = new Texture2D(2, 2, TextureFormat.ARGB32, false);
        healthTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        magicTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        // set the pixel values
        Color localColor = new Color(.7f, .9f, .8f);
        hudTexture.SetPixel(0, 0, new Color(.6f, .8f, .9f));
        hudTexture.SetPixel(1, 0, localColor);
        hudTexture.SetPixel(0, 1, new Color(.9f, .6f, .9f));
        hudTexture.SetPixel(1, 1, new Color(.9f, .8f, .6f));

        healthTexture.SetPixel(0, 0, new Color(1f, 0f, 0f));

        magicTexture.SetPixel(0, 0, new Color(0f, 0f, 1f));

        // Apply all SetPixel calls
        hudTexture.Apply();
        magicTexture.Apply();
        healthTexture.Apply();
    }

    void OnGUI()
    {
        if (playing)
        {
            //GUI.contentColor = Color.blue;
            currentStyle.normal.background = hudTexture;
            GUI.Box(new Rect(0, 0, screenW / 3, screenH / 8), localMaster.GetComponent<InventoryMenu>().getName(), currentStyle);
            //GUI.contentColor = Color.black;
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(5, screenH / 26, screenW / 10, screenH / 10), "Health:");
            currentStyle.normal.background = healthTexture;
            GUI.Box(new Rect(screenW / 9, screenH / 20, screenW / 5, screenH / 38), "", currentStyle);
            GUI.contentColor = Color.blue;
            currentStyle.normal.background = magicTexture;
            GUI.Label(new Rect(5, screenH / 14, screenW / 10, screenH / 10), "Magic:");
            GUI.Box(new Rect(screenW / 9, screenH / 12, screenW / 5, screenH / 35), "", currentStyle);
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
