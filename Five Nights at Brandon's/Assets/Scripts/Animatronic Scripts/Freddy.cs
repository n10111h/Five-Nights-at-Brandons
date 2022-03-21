using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freddy : MonoBehaviour
{
    public GameObject powerUI;
    private float power;
    public GameObject player;
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
            if (Time.time - time > 15)
            {
                time = Time.time;
            }
            transform.position = new Vector3(0.145f, 0.553f, 6.62f);
            transform.rotation = Quaternion.Euler(90, 90, 90);
            if (Time.time - time > 10) Application.Quit();
        }

        else
        {
            float rand = Random.Range(0.0f, 999.0f);
            if (rand < level) pos++;
        }
    }
}
