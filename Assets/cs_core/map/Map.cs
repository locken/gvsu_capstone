using UnityEngine;
using System.Collections;

public class Map: MonoBehaviour {
    Random r = new Random();
    int length, height;
    int seed;

	// Use this for initialization
	void Start () {
        seed = 69;
        Random.seed = seed;
        length = Random.Range(15, 25);
        height = Random.Range(20, 30);
        Debug.Log("Seed: " + seed);
        Debug.Log("Map Size: " + length + 'x' + height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
