using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRInputTest : MonoBehaviour
{
    public InputActionReference testActionReference;
    private InputAction testAction;
    public float _xAxis;
    public float _yAxis;

    void Start()
    {
        testAction = testActionReference.action;
        testAction.performed += ActivateBehavior;
    }

    private void ActivateBehavior(InputAction.CallbackContext context)
    {
        // 获取2D向量的值
        Vector2 inputVector = context.ReadValue<Vector2>();

        // 检查输入是否为零向量
        if (inputVector == Vector2.zero)
        {
            _xAxis = 0f;
            _yAxis = 0f;
        }
        else
        {
            // 访问 primary2DAxis 的 X 和 Y 值
            _xAxis = inputVector.x;
            _yAxis = inputVector.y;
        }
    }
}
