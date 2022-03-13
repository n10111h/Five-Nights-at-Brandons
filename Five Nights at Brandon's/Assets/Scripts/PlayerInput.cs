using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{


    // Update is called once per frame
    float AngleAboutY(Transform obj)
    {
        Vector3 objFwd = obj.forward;
        float angle = Vector3.Angle(objFwd, Vector3.forward);
        float sign = Mathf.Sign(Vector3.Cross(objFwd, Vector3.forward).y);
        return angle * sign;
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (AngleAboutY(this.transform) > 130 || AngleAboutY(this.transform) < 0) transform.Rotate(0f, 1f, 0f, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (AngleAboutY(this.transform) < -130 || AngleAboutY(this.transform) > 0) transform.Rotate(0f, -1f, 0f, Space.World);
        }
    }
}
