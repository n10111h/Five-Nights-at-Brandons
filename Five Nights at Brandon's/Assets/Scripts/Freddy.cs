using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freddy : MonoBehaviour
{
    public GameObject powerUI;
    private float power;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        power = powerUI.GetComponent<power>().powerPercent;
        if (power>0)
        {

        }
        else
        {

        }
    }
    void FixedUpdate()
    {
        if (power <= 0)
        {
            transform.position = new Vector3(0.145f, 0.553f, 6.62f);
        }
    }
}
