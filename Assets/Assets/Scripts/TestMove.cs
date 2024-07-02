using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float changeDirDeTime = 5.0f;
    public float moveSpeed = 1.0f;

    private Vector3 dir;
    private float _timer;
    
    void Start()
    {
        _timer = changeDirDeTime;
        dir = transform.forward;
    }
    
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = changeDirDeTime;
            dir = -dir;
        }

        transform.position += moveSpeed * Time.deltaTime * dir;
    }
}
