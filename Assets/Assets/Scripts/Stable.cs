using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stable : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Transform;
    public Transform stable;

    // Update is called once per frame
    void Update()
    {
        Transform.position = stable.position;
    }
}
