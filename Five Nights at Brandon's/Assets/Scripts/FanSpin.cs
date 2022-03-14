using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0.0f, 60.0f, 0.0f, Space.Self);
    }
}
