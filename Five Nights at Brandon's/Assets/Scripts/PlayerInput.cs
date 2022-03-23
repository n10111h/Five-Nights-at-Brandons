using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    private bool dDown;
    public bool camIsOpen;
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
    public GameObject bonnie;
    public GameObject chica;
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
                powerUI.GetComponent<power>().powerPercent -= 0.75f*Time.deltaTime;
            else
                rightDoorClosed = false;
        }
        if (leftDoorClosed)
        {
            if (powerUI.GetComponent<power>().powerPercent > 0)
                powerUI.GetComponent<power>().powerPercent -= 0.75f*Time.deltaTime;
            else
                leftDoorClosed = false;
        }
        if (leftLightEn)
        {
            if (powerUI.GetComponent<power>().powerPercent > 0)
                powerUI.GetComponent<power>().powerPercent -= 0.2f*Time.deltaTime;
            else
                leftLightEn = false;
        }
        if (rightLightEn)
        {
            if (powerUI.GetComponent<power>().powerPercent > 0)
                powerUI.GetComponent<power>().powerPercent -= 0.2f*Time.deltaTime;
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
            leftLight.intensity = 2;
        else
            leftLight.intensity = 0;
        if (rightLightEn)
            rightLight.intensity = 2;
        else
            rightLight.intensity = 0;
    }
    void camIn()
    {
        if (Input.GetKeyDown("space"))
        {
            if (camIsOpen)
            {
                camIsOpen = false;
            }
            else
            {
                camIsOpen = true;
            }
        }
        if (camIsOpen)
        {
            if (powerUI.GetComponent<power>().powerPercent > 0)
                powerUI.GetComponent<power>().powerPercent -= 0.1f*Time.deltaTime;
            else
                camIsOpen = false;
            if (bonnie.GetComponent<Bonnie>().pos == 6 || chica.GetComponent<Chica>().pos == 4)
                camIsOpen = false;
        }

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
        camIn();
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
