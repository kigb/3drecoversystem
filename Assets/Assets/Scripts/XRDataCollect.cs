using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRDataCollect : MonoBehaviour
{
    void Update()
    {
        // 检查是否支持眼动追踪
        if (XRSettings.isDeviceActive)
        {
            // 获取主要眼睛的输入设备
            InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftEye); // 或者 XRNode.RightEye

            // 声明用于存储眼动数据的结构体
            Eyes eyes;

            // 尝试获取眼动数据
            if (device.TryGetFeatureValue(CommonUsages.eyesData, out eyes))
            {
                // 输出眼动数据
                eyes.TryGetLeftEyePosition(out Vector3 LeftEyePosition);
                Debug.Log("左眼位置：" + LeftEyePosition);
                eyes.TryGetRightEyePosition(out Vector3 RightEyePosition);
                Debug.Log("右眼位置：" + RightEyePosition);
                eyes.TryGetLeftEyeRotation(out Quaternion LeftRotation);
                Debug.Log("左眼旋转角度：" + LeftRotation);
            }
        }
        else
        {
            Debug.Log("不支持眼动喵");
        }
    }
}
