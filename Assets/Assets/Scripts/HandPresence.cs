using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice;
    // Start is called before the first frame update
    //void Start()
    //{

    //    List<InputDevice> devices = new List<InputDevice>();
    //    InputDeviceCharacteristics rightController = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
    //    InputDevices.GetDevicesWithCharacteristics(rightController, devices);

    //    foreach(var item in devices)
    //    {
    //        Debug.Log("HandePresent Start");
    //        Debug.Log("HandPresence start" + item.name + item.characteristics);
    //    }
    //    if(devices.Count > 0)
    //    {
    //        targetDevice = devices[0];
    //    }

    //}
    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        foreach (var item in devices) {
            Debug.Log(item.name + item.characteristics);
        
        }

    }

    //// Update is called once per frame
    //void Update()
    //{
    //    targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
    //    if (primaryButtonValue)
    //    {
    //        Debug.Log("pressing primary button");
    //    }
    //    targetDevice.TryGetFeatureValue(CommonUsages.trigger,out float triggerValue);
    //    if (triggerValue > 0.1f)
    //    {
    //        Debug.Log("pressing trigger" +  triggerValue);
    //    }
    //    targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis,out Vector2 axisValue);
    //    if (axisValue != Vector2.zero)
    //    {
    //        Debug.Log("pressing 2Daxis" + axisValue);
    //    }
    //}
}
