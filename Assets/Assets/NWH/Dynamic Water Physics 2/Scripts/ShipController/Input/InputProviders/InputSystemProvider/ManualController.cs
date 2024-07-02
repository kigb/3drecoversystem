using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualController : MonoBehaviour
{
    public float _xAxis;
    public float _yAxis;
    public PowerEventSO powerEvent;
    // Start is called before the first frame update
    private void Start()
    {
        _xAxis = 0;
        _yAxis = 0;
    }
    private void OnEnable()
    {
        powerEvent.OnEventRaised += Accelerate;
    }

    private void OnDisable()
    {
        powerEvent.OnEventRaised -= Accelerate;
    }

    private void Accelerate(Vector2 arg0)
    {
        if (_yAxis + arg0.y <= 0.5)
        {
            _yAxis += arg0.y;
        }

        if ((_xAxis + arg0.x <= 0.8)&& (_xAxis + arg0.x >= -0.8))
        {
            Debug.Log(_xAxis + "  "+arg0.x);
            _xAxis += arg0.x;
        }
    }

    void Update()
    {
        _yAxis -= 0.1f * Time.deltaTime;
        _yAxis = Mathf.Max(_yAxis, 0f);
        if (_xAxis > 0f)
        {
            _xAxis -= 0.05f * Time.deltaTime;
            _xAxis = Mathf.Max(_xAxis, 0f); // 确保不小于零
        }
        else if (_xAxis < 0f)
        {
            _xAxis += 0.05f * Time.deltaTime;
            _xAxis = Mathf.Min(_xAxis, 0f); // 确保不大于零
        }
        //Debug.Log(_xAxis + " " + _yAxis);
    }
}
