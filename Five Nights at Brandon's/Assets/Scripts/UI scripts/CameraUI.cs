using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraUI : MonoBehaviour
{
    private float yPos;
    public bool IsOpen;
    private RectTransform rt;
    private float height;
    public RawImage CamDisplay;
    public Texture cam1;
    public Texture cam2;
    public Texture cam3;
    public Texture cam4;
    public Texture cam5;
    public Texture cam6;
    public Texture cam7;
    public Texture cam8;
    public GameObject powerUI;
    public GameObject Player;
    public int camNum;
    public bool callable;
    // Start is called before the first frame update
    void Start()
    {
        height = Screen.height;
        rt = GetComponent<RectTransform>();
        IsOpen = false;
        rt.sizeDelta = new Vector2(Screen.width, height);
        camNum = 6;
        callable = false;
    }
    public void changeCam(int num)
    {
        if (callable)
        {
            camNum = num;
            switch (camNum)
            {
                case 1:
                    CamDisplay.texture = cam1;
                    break;
                case 2:
                    CamDisplay.texture = cam2;
                    break;
                case 3:
                    CamDisplay.texture = cam3;
                    break;
                case 4:
                    CamDisplay.texture = cam4;
                    break;
                case 5:
                    CamDisplay.texture = cam5;
                    break;
                case 6:
                    CamDisplay.texture = cam6;
                    break;
                case 7:
                    CamDisplay.texture = cam7;
                    break;
                case 8:
                    CamDisplay.texture = cam8;
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsOpen = Player.GetComponent<PlayerInput>().camIsOpen;
        yPos = rt.anchoredPosition.y;
        if (IsOpen)
        {
            // changeCam(camNum);
            if (yPos < 0)
            {
                yPos += 30;
                rt.anchoredPosition = new Vector2(0.0f, yPos);
            }
            else
            {
                callable = true;
            }
        }
        else
        {
            callable = false;
            if (yPos > -1*height)
            {
                yPos -= 30;
                rt.anchoredPosition = new Vector2(0.0f, yPos);
            }
        }
    }
}
