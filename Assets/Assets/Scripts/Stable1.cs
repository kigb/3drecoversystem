using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stable1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pullRod;
    public Transform point;

    // Update is called once per frame
    void Update()
    {
        pullRod.position = point.position;
    }
}
