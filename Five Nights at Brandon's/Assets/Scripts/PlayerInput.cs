using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    private bool dDown;
    private bool aDown;
    public GameObject rightDoor;
    public GameObject leftDoor;
    public GameObject powerUI;
    public Light leftLight;
    public Light rightLight;
    public bool rightDoorClosed;
    public bool leftDoorClosed;
    public bool leftLightEn;
    public bool rightLightEn;
    // Update is called once per frame
    float AngleAboutY(Transform obj)
    {
        Vector3 objFwd = obj.forward;
        float angle = Vector3.Angle(objFwd, Vector3.forward);
        float sign = Mathf.Sign(Vector3.Cross(objFwd, Vector3.forward).y);
        return angle * sign;
    }
    void viewIn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            dDown = true;
        }
        else
        {
            dDown = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            aDown = true;
        }
        else
        {
            aDown = false;
        }
    }
    void viewOut()
    {
        if (dDown)
        {
            if (AngleAboutY(this.transform) > 130 || AngleAboutY(this.transform) < 0) transform.Rotate(0f, 5f, 0f, Space.World);
        }
        if (aDown)
        {
            if (AngleAboutY(this.transform) < -130 || AngleAboutY(this.transform) > 0) transform.Rotate(0f, -2f, 0f, Space.World);
        }
    }
    void doorIn()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            leftDoorClosed = !leftDoorClosed;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            rightDoorClosed = !rightDoorClosed;
        }
    }
    void doorOut()
    {
        if (leftDoorClosed)
        {
            if (leftDoor.transform.position.y > 0.65) leftDoor.transform.position = new Vector3(leftDoor.transform.position.x, leftDoor.transform.position.y-0.05f, leftDoor.transform.position.z);
        }
        else
        {
            if (leftDoor.transform.position.y < 1.8) leftDoor.transform.position = new Vector3(leftDoor.transform.position.x, leftDoor.transform.position.y + 0.05f, leftDoor.transform.position.z);
        }
        if (rightDoorClosed)
        {
            if (rightDoor.transform.position.y > 0.65) rightDoor.transform.position = new Vector3(rightDoor.transform.position.x, rightDoor.transform.position.y - 0.05f, rightDoor.transform.position.z);
        }
        else
        {
            if (rightDoor.transform.position.y < 1.8) rightDoor.transform.position = new Vector3(rightDoor.transform.position.x, rightDoor.transform.position.y + 0.05f, rightDoor.transform.position.z);
        }
    }
    void checkPowerUse()
    {
        if (rightDoorClosed)
        {
            if (powerUI.GetComponent<power>().powerPercent > 0)
                powerUI.GetComponent<power>().powerPercent -= 0.1f;
            else
                rightDoorClosed = false;
        }
        if (leftDoorClosed)
        {
            if (powerUI.GetComponent<power>().powerPercent > 0)
                powerUI.GetComponent<power>().powerPercent -= 0.1f;
            else
                leftDoorClosed = false;
        }
        if (leftLightEn)
        {
            if (powerUI.GetComponent<power>().powerPercent > 0)
                powerUI.GetComponent<power>().powerPercent -= 0.1f;
            else
                leftLightEn = false;
        }
        if (rightLightEn)
        {
            if (powerUI.GetComponent<power>().powerPercent > 0)
                powerUI.GetComponent<power>().powerPercent -= 0.1f;
            else
                rightLightEn = false;
        }
    }
    void lightIn()
    {
        if (Input.GetKey(KeyCode.Z))
            leftLightEn = true;
        else
            leftLightEn = false;
        if (Input.GetKey(KeyCode.C))
            rightLightEn = true;
        else
            rightLightEn = false;
    }
    void lightOut()
    {
        if (leftLightEn)
            leftLight.intensity = 1;
        else
            leftLight.intensity = 0;
        if (rightLightEn)
            rightLight.intensity = 1;
        else
            rightLight.intensity = 0;
    }
    void Start()
    {
        dDown = false;
        aDown = false;
        rightDoorClosed = false;
        leftDoorClosed = false;
        leftLightEn = false;
        rightLightEn = false;
    }
    void Update()
    {
        lightIn();
        viewIn();
        doorIn();
        checkPowerUse();
    }
    void FixedUpdate()
    {
        viewOut();
        doorOut();
        lightOut();
    }
}
