using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOff : MonoBehaviour
{
    public GameObject powerUI;
    void Update()
    {
        if (powerUI.GetComponent<power>().powerPercent <= 0)
        {
            GetComponent<Light>().intensity = 0;
        }
    }
}
