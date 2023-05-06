using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public bool fire = true;
    public GameObject fireEffect, smokeEffect;
    public GameObject missleExplosion;
    public GameObject explosionClone;
    public float raycastDistance = 1.0f;
    public bool followTarget = false;
    public GameObject target;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (fire)
        {
            fireEffect.SetActive(true);
            smokeEffect.SetActive(true);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.SetParent(null);
            rb.isKinematic = false;
            rb.velocity = transform.forward * speed;
            StartCoroutine(destroyAfter());

            // Cast a ray to check for collisions
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                OnHit();
            }
        }

        if(followTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }

    // Called when the missile collides with something
    void OnHit()
    {
        fire = false;
        explosionClone = Instantiate(missleExplosion, transform.position, Quaternion.identity);
        Debug.Log("Exploded");
        StartCoroutine(destroyEffect());
    }

    IEnumerator destroyEffect()
    {
        yield return new WaitForSeconds(2f);
        Destroy(explosionClone);
        Destroy(gameObject);
    }

    IEnumerator destroyAfter()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}