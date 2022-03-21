using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chica : MonoBehaviour
{
    public GameObject powerUI;
    private float power;
    private float time;
    public short level;
    private int pos;
    void Start()
    {
        time = Time.time;
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
        if (power < 0)
        {
            
        }
        else
        {
            float rand = Random.Range(0.0f, 999.0f);
            if (rand < level) pos++;
        }
    }
}
