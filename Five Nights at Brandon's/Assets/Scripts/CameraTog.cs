using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTog : MonoBehaviour
{
    private float yPos;
    private bool IsOpen;
    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        IsOpen = false;
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (IsOpen)
            {
                IsOpen = false;
            }
            else
            {
                IsOpen = true;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        yPos = rt.anchoredPosition.y;
        if (IsOpen)
        {
            if (yPos < 0)
            {
                yPos += 30;
                rt.anchoredPosition = new Vector2(0.0f, yPos);
            }
        }
        else
        {
            if (yPos > -600)
            {
                yPos -= 30;
                rt.anchoredPosition = new Vector2(0.0f, yPos);
            }
        }
    }
}
