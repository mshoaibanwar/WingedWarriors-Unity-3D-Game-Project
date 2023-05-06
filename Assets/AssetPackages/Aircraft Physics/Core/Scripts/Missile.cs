using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public bool fire = false;
    public bool followTarget = false;
    public GameObject target;
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
            StartCoroutine(destroyAfter());
        }
        if(followTarget)
        {
            //transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Sensor")
        {
            fire = false;
            Debug.Log("Exploded");
        }
    }

    IEnumerator destroyAfter()
    {
        yield  return new WaitForSeconds(50f);
        Destroy(gameObject);
    }

}
