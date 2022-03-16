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
        if (powerPercent >= 0)
        {
            GetComponent<Text>().text = "POWER: " + Math.Floor(powerPercent) + '%';
        }
        else
        {
            GetComponent<Text>().fontSize = 14;
            GetComponent<Text>().text = "Imagine running out of power.";
        }
    }
}
