using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
    int screenW = Screen.width;
    int screenH = Screen.height;
    int currentHealth, localCurrentHealth, enemyCount, currentMagic;
    float oneOneHund;
    GameObject localMaster, localPlayer;
    bool playing, afterStart, gameOver;
    private GUIStyle currentStyle = new GUIStyle();
    Texture2D hudTexture, healthTexture, magicTexture;

    // Use this for initialization
    void Start () {
        enemyCount = 0;
        gameOver = false;
        playing = afterStart = true;
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
        currentHealth = currentMagic = 100;
        //Debug.Log("current health = "  + currentHealth);
        oneOneHund = currentHealth / 100;
        //Debug.Log("100th = " + oneOneHund);
        healthTexture.Apply();
    }

    void OnGUI()
    {
        if (playing)
        {
            //GUI.contentColor = Color.blue;
            currentStyle.normal.background = hudTexture;
            GUI.Box(new Rect(0, 0, screenW / 3, screenH / 6), localMaster.GetComponent<InventoryMenu>().getName(), currentStyle);
            //GUI.contentColor = Color.black;
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(5, screenH / 26, screenW / 10, screenH / 10), "Health:");
            currentStyle.normal.background = healthTexture;
            GUI.Box(new Rect(screenW / 9, screenH / 20, currentHealth, screenH / 34), "", currentStyle);
            GUI.contentColor = Color.blue;
            currentStyle.normal.background = magicTexture;
            GUI.Label(new Rect(5, screenH / 14, screenW / 10, screenH / 10), "Magic:");
            GUI.Box(new Rect(screenW / 9, screenH / 12, currentMagic, screenH / 35), "", currentStyle);
            if (enemyCount > 0) {
                GUI.Label(new Rect(5, screenH / 9, screenW / 6, screenH / 10), "Enemies left: " + enemyCount.ToString());
            }
            else
            {
                GUI.Label(new Rect(5, screenH / 9, screenW / 6, screenH / 10), "Enemies left: none, You Win!");
            }
        }
        if (gameOver)
        {
            Time.timeScale = 0;
            GUI.Label(new Rect(screenW / 2, screenH / 2, screenW / 8, screenH / 4), "Game Over");
            if(GUI.Button(new Rect(screenW / 2, screenH / 4, screenW / 4, screenH / 14), "Main Menu"))
            {
                Application.LoadLevel(0);
            }

        }
    }
    public void CycleGameOver()
    {
        gameOver = true;
    }

    public void CyclePlaying()
    {
        playing = !playing;
    }

    public void DecrementEnemy()
    {
        if (enemyCount > 0)
        {
            enemyCount--;
        }
    }

    public void IncrementEnemy()
    {
        enemyCount++;
    }

    // Update is called once per frame
    void Update () {
        if (afterStart)
        {
            afterStart = false;
            localPlayer = GameObject.Find("Player");
            localCurrentHealth = localPlayer.GetComponent<Playable>().Health;
            localPlayer.GetComponent<Playable>().CharName = localMaster.GetComponent<InventoryMenu>().getName();
        }
        if(localCurrentHealth != localPlayer.GetComponent<Playable>().Health)
        {
            //Debug.Log("current player health" + currentHealth);
            if (currentHealth > 0)
            {
                currentHealth = currentHealth - (int)oneOneHund;
            }
            //Debug.Log("new player health" + currentHealth);
            localCurrentHealth = localPlayer.GetComponent<Playable>().Health;
        }
	}
}
