using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject MachineGun;
    public GameObject Bullet;
    public GameObject missilePrefab;
    public GameObject[] missile;
    public GameObject target;
    private GameObject missileCloned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            target = null;
            Debug.Log("Target Reset");
        }

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, MachineGun.transform.position + new Vector3(0, 0.2f, 1.6f), MachineGun.transform.rotation);
        }
        if(Input.GetMouseButtonDown(1))
        {
            missileCloned = Instantiate(missilePrefab, missile[(int)Random.RandomRange(0f, 2f)].transform.position, missile[0].transform.rotation);
            if(target != null)
            {
                missileCloned.GetComponent<Missile>().target = target;
                missileCloned.GetComponent<Missile>().followTarget = true;
            }
        }
    }
}
