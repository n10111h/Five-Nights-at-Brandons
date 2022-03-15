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
    void Start()
    {
        dDown = false;
        aDown = false;
        rightDoorClosed = false;
        leftDoorClosed = false;
    }
    void Update()
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
        if (Input.GetKey(KeyCode.Q))
        {
            leftDoorClosed = true;
        }
        else
        {
            leftDoorClosed = false;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rightDoorClosed = true;
        }
        else
        {
            rightDoorClosed = false;
        }
    }
    void FixedUpdate()
    {
        if (dDown)
        {
            if (AngleAboutY(this.transform) > 130 || AngleAboutY(this.transform) < 0) transform.Rotate(0f, 1f, 0f, Space.World);
        }
        if (aDown)
        {
            if (AngleAboutY(this.transform) < -130 || AngleAboutY(this.transform) > 0) transform.Rotate(0f, -1f, 0f, Space.World);
        }
    }
}
