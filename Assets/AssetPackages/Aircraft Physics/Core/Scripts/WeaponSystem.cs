using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject MachineGun;
    public GameObject Bullet;
    public GameObject[] missile;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            target = null;
            Debug.Log("Target Resetted!");
        }
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
                        if(target!= null)
                        {
                            missile[i].GetComponent<Missile>().target = target;
                            missile[i].GetComponent<Missile>().followTarget = true;
                        }
                        missile[i].GetComponent<Missile>().fire = true;
                        missile[i] = null;
                        break;
                    }
                }
            }
        }
    }
}
