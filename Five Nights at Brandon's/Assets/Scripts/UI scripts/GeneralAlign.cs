using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAlign : MonoBehaviour
{
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
