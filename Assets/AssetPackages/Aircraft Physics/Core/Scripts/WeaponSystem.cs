using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject MachineGun;
    public GameObject Bullet;
    public GameObject missilePrefab;
    public GameObject[] missile;
    [HideInInspector]
    public GameObject target;
    private GameObject missileCloned;
    private GameObject bulletCloned;
    public AudioClip bulletFire;
    public AudioClip missileFire;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        missile[0] = GameObject.FindGameObjectWithTag("Player").GetComponent<AirplaneController>().Missiles[0];
        missile[1] = GameObject.FindGameObjectWithTag("Player").GetComponent<AirplaneController>().Missiles[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            target = null;
            GameObject.FindGameObjectWithTag("EnemyDetector").GetComponent<EnemyDetector>().targetLocked = false;
            Debug.Log("target Reset!");
        }
        if(Input.GetMouseButtonDown(0))
        {
            audioSource.volume = 1f;
            audioSource.PlayOneShot(bulletFire);
            for(int i=0; i<=6; i++)
            {
                bulletCloned = Instantiate(Bullet, MachineGun.transform.position + new Vector3(0, 0.2f, 1.6f), MachineGun.transform.rotation);
                if(target != null)
                {
                    bulletCloned.GetComponent<Bullet>().target = target;
                    bulletCloned.GetComponent<Bullet>().followTarget = true;
                }
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            audioSource.volume = 0.4f;
            audioSource.PlayOneShot(missileFire);
            missileCloned = Instantiate(missilePrefab, missile[(int)Random.RandomRange(0f, 2f)].transform.position, missile[0].transform.rotation);
            if(target != null)
            {
                missileCloned.GetComponent<Missile>().target = target;
                missileCloned.GetComponent<Missile>().followTarget = true;
            }
        }
    }
}
