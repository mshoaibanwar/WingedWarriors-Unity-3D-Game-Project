using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool followTarget = false;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(followTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 6f);
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        StartCoroutine(DestroyAfter());
    }
    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
