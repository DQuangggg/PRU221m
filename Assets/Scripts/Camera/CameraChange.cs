using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    // Update is called once per frame
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    public CinemachineVirtualCamera camera3;

    void Update()
    {
        if (transform.position.x >= 27)
        {
            camera1.enabled = false;
            camera2.enabled = true;
            camera3.enabled = false;
        }
        if(transform.position.x >= 126)
        {
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = true;
        }
        if (transform.position.x < 27)
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;
        }
    }
}
