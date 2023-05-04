using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public bool fire = false;
    public GameObject fireEffect, smokeEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fire)
        { 
            fireEffect.SetActive(true);
            smokeEffect.SetActive(true);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.SetParent(null);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        fire = false;
    }
}
