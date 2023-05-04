using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject MachineGun;
    public GameObject Bullet;
    public GameObject[] missile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, MachineGun.transform.position + new Vector3(0, 0.2f, 1.6f), MachineGun.transform.rotation);
        }
        if(Input.GetMouseButtonDown(1))
        {
            for(int i=0; i<missile.Length; i++)
            {
                if(missile[i] != null)
                {
                    if(missile[i].GetComponent<Missile>().fire != true)
                    {
                        missile[i].GetComponent<Missile>().fire = true;
                        break;
                    }
                }
            }
        }
    }
}
