using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlaneLoader : MonoBehaviour
{
    public GameObject[] planes;
    void Awake()
    {
        planes[PlayerPrefs.GetInt("SelectedPlane", 0)].SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
