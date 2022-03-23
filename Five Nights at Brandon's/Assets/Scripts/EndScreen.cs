using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private float t;
    void Start()
    {
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (t > 5) Application.Quit();
    }
}
