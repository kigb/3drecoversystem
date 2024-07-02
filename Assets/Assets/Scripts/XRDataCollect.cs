using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRDataCollect : MonoBehaviour
{
    void Update()
    {
        // ����Ƿ�֧���۶�׷��
        if (XRSettings.isDeviceActive)
        {
            // ��ȡ��Ҫ�۾��������豸
            InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftEye); // ���� XRNode.RightEye

            // �������ڴ洢�۶����ݵĽṹ��
            Eyes eyes;

            // ���Ի�ȡ�۶�����
            if (device.TryGetFeatureValue(CommonUsages.eyesData, out eyes))
            {
                // ����۶�����
                eyes.TryGetLeftEyePosition(out Vector3 LeftEyePosition);
                Debug.Log("����λ�ã�" + LeftEyePosition);
                eyes.TryGetRightEyePosition(out Vector3 RightEyePosition);
                Debug.Log("����λ�ã�" + RightEyePosition);
                eyes.TryGetLeftEyeRotation(out Quaternion LeftRotation);
                Debug.Log("������ת�Ƕȣ�" + LeftRotation);
            }
        }
        else
        {
            Debug.Log("��֧���۶���");
        }
    }
}
