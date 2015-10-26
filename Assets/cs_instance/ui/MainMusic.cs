using UnityEngine;
using System.Collections;

public class MainMusic : MonoBehaviour {

    private static MainMusic instance = null;
    public AudioClip themeMusic;
    //private AudioSource musicSource;
    public static MainMusic Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        //musicSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        //instance.addComponent()
        themeMusic = (AudioClip) Resources.Load("audio/the_attack_is_on.mp3");
        AudioSource.PlayClipAtPoint(themeMusic, transform.position, 0.8F);
        //musicSource.clip = themeMusic;
        //musicSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
