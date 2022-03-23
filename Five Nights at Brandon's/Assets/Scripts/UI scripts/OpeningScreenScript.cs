using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpeningScreenScript : MonoBehaviour
{
    private byte imageTrans;
    private float pace;
    void Start()
    {
        pace = Time.time;
    }
    void FixedUpdate()
    {
        if (Time.time - pace > 2f)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(2 * Screen.width, 2 * Screen.height);
        }

    }
}
