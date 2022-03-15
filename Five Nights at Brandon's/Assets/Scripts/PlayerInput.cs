using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    private bool dDown;
    private bool aDown;
    public GameObject rightDoor;
    public GameObject leftDoor;
    public bool rightDoorClosed;
    public bool leftDoorClosed;
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
    void Start()
    {
        dDown = false;
        aDown = false;
        rightDoorClosed = false;
        leftDoorClosed = false;
    }
    void Update()
    {
        viewIn();
        doorIn();
    }
    void FixedUpdate()
    {
        viewOut();
        doorOut();
    }
}
