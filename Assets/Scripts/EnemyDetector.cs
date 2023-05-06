using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public int numberOfRays = 10;
    public float angle = 90;
    public WeaponSystem weaponSystem;

    Quaternion rotation;
    public float rayRange = 2000f;

    public bool targetLocked = false;
    public AudioClip TargetLcokedAudio;
    // Start is called before the first frame update
    void Awake()
    {
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberOfRays; i++)
        {
            var rotationMod = Quaternion.AngleAxis((i / (float)numberOfRays) * angle, this.transform.forward);
            var direction = rotation * rotationMod * Vector3.up;
            rotation = this.transform.rotation;
            var ray = new Ray(this.transform.position, direction);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, rayRange))
            {
                if (hitInfo.transform.gameObject.tag == "Enemy")
                {
                    if(!targetLocked)
                    {
                        GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>().PlayOneShot(TargetLcokedAudio);
                        targetLocked = true;
                    }
                    weaponSystem.target = hitInfo.transform.gameObject;
                    Debug.Log("Target Updated!");
                    break;
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < numberOfRays; i++)
        {
            var rotationMod = Quaternion.AngleAxis((i / (float)numberOfRays) * angle, this.transform.forward);
            var direction = rotation * rotationMod * Vector3.up;
            Gizmos.DrawRay(this.transform.position, direction);
        }
    }
}
