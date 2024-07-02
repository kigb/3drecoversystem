using System;
using System.Collections;
using System.Collections.Generic;
using Crest;
using NWH.DWP2.ShipController;
using UnityEngine;

public class TestRacer : MonoBehaviour
{
    private AdvancedShipController _advancedShipController;

    public SphereWaterInteraction[] sphereWaterInteractions;
    
    private float _accumulatedPower;            //为了防止Power突变为0，这里对其进行平滑处理
    private float _accumulatedPowerRate = 0.99f; //平滑处理的系数
    
    private void Awake()
    {
        _advancedShipController = GetComponent<AdvancedShipController>();
    }

    private void Update()
    {
        float power = _advancedShipController.engines[0].Thrust / _advancedShipController.engines[0].maxThrust;
        _accumulatedPower = _accumulatedPowerRate *_accumulatedPower + (1 - _accumulatedPowerRate) * power;
        //Debug.Log(_accumulatedPower);
        //根据引擎的推力来调整效果
        for(int i = 0; i < sphereWaterInteractions.Length; i++)
        {
            //radius随着推力增大也增大
            sphereWaterInteractions[i]._radius = _accumulatedPower * 0.7f;
            //innerSphereMultiplier随着推力增大增大，最大是9，最小是0
            sphereWaterInteractions[i]._innerSphereMultiplier = 9 * _accumulatedPower;
            //1到4
            sphereWaterInteractions[i]._weight = 1 + 3 * _accumulatedPower; 
        }
    }
}
