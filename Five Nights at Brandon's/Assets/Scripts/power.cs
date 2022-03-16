using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class power : MonoBehaviour
{
    public float powerPercent;
    void Start()
    {
        powerPercent = 100;
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        GetComponent<Text>().text = "POWER: " + Math.Floor(powerPercent) + '%';
    }
}
