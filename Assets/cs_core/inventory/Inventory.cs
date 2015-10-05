using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    public List<Items> items = new List<Items>();

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {

    }

    [System.Serializable]
public class Items
{
    public Transform itemTransform;
}

    
}
