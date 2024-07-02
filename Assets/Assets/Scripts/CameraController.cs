using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Cameras;
    public CameraEventSO cameraEvent;
    private void OnEnable()
    {
        cameraEvent.OnEventRaised += CameraChange;
    }

    private void OnDisable()
    {
        cameraEvent.OnEventRaised -= CameraChange;
    }

    private void CameraChange(int arg0)
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i == arg0)
            {
                Cameras[i].SetActive(true);
            }
            else
            {
                Cameras[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
