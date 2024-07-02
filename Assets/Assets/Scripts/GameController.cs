using NWH.Common.FloatingOrigin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int shipType;
    public GameObject orign;
    public GameObject[] Cameras;

    private void Start()
    {
        orign.SetActive(true);
    }

    public void CameraChange()
    {
        orign.SetActive(false);
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i != shipType)
            {
                Cameras[i].SetActive(false);
            }
        }
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i == shipType)
                Cameras[i].SetActive(true);
        }
            
    }

    // Update is called once per frame
   
}
