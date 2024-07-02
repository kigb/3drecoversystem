using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerByLever : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Lever;
    public GameObject steeringWheel;
    public Transform dicPoint;
    public Transform stablePoint;
    public Transform stablePoint0;
    public Transform dicPoint1;
    public Transform stablePoint1;
    public PowerEventSO powerEvent;
    private float max;
    private float init;


    private void Start()
    {
        max = 64;
        init = 278;
    }
    // Update is called once per frame
    void Update()
    {

        float dir = dicPoint1.position.y - stablePoint1.position.y;

        if (dir < 0)
            dir = dir / 0.66f;
        else
            dir = dir / 0.4f;

        dir = -dir;

        float angle1 = Vector3.Angle(dicPoint.position - stablePoint.position, stablePoint0.position - stablePoint.position);

        int b = (angle1 < 90f) ? 1 : -1;

        float tmp =( Lever.transform.rotation.eulerAngles.x - init)*b + 5;

        if (tmp > -10 && tmp < 10)
        {
            tmp = 0;
        }
        else tmp = tmp / max;

        powerEvent.RaiseEvent(new Vector2 (dir/2, tmp));
    }
}
