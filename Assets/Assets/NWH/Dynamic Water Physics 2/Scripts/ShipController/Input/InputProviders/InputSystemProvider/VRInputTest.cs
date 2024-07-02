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
        // ��ȡ2D������ֵ
        Vector2 inputVector = context.ReadValue<Vector2>();

        // ��������Ƿ�Ϊ������
        if (inputVector == Vector2.zero)
        {
            _xAxis = 0f;
            _yAxis = 0f;
        }
        else
        {
            // ���� primary2DAxis �� X �� Y ֵ
            _xAxis = inputVector.x;
            _yAxis = inputVector.y;
        }
    }
}
