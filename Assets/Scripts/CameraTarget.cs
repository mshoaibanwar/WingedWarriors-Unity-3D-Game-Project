using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTarget : MonoBehaviour
{
    public CinemachineVirtualCamera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        camera.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
