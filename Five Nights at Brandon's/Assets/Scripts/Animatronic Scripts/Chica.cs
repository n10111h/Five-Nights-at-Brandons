using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chica : MonoBehaviour
{
    public GameObject powerUI;
    private float power;
    private float time;
    private float jumpTime;
    private float whenTime;
    public short level;
    public int pos;
    public GameObject player;
    void posUpdate()
    {
        switch (pos)
        {
            case 0:
                transform.position = new Vector3(0.97f, 1.087f, -5.585f);
                transform.rotation = Quaternion.Euler(90, 130, 90);
                break;
            case 1:
                transform.position = new Vector3(-4.5f, 0.6f, -1.9f);
                transform.rotation = Quaternion.Euler(90, 180, 130);
                break;
            case 2:
                transform.position = new Vector3(-1.356f, 0.6f, 4.183f);
                transform.rotation = Quaternion.Euler(90, 180, 150);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(90, 130, 90);
                if (player.GetComponent<PlayerInput>().rightLightEn)
                    transform.position = new Vector3(-1.6f, 0.6f, 5.1f);
                else
                    transform.position = new Vector3(50f, 50f, 50f);
                if (time == 0.0f) time = Time.time;
                if (Time.time - time > 3)
                {
                    float rand = Random.Range(0.0f, 999.0f);
                    if (player.GetComponent<PlayerInput>().rightDoorClosed)
                    {
                        if (rand > (level * 40))
                        {
                            pos = 2;
                            time = 0;
                        }
                    }
                    else
                    {
                        if (rand < (level))
                            pos = 4;
                    }
                }
                break;
            case 4:
                if (Time.time - jumpTime == Time.time)
                {
                    jumpTime = Time.time;
                }
                transform.position = new Vector3(0.145f, 0.553f, 6.62f);
                transform.rotation = Quaternion.Euler(90, 90, 90);
                if (Time.time - jumpTime > 10) Application.Quit();
                break;
            default:
                break;

        }
    }
    void Start()
    {
        time = 0;
        pos = 0;
        jumpTime = 0;
        whenTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        power = powerUI.GetComponent<power>().powerPercent;
        if (power > 0)
        {

        }
        else
        {

        }
    }
    void FixedUpdate()
    {
        if (level != 0)
        {
            if (power < 0)
            {

            }
            else
            {
                if (Time.time - whenTime == Time.time) whenTime = Time.time;
                if (Time.time - whenTime > (float)(20 / level))
                {
                    float rand = Random.Range(0.0f, 99.0f);
                    if (rand < level)
                    {
                        if (pos < 3) pos++;
                        whenTime = 0;
                    }
                }
            }
            posUpdate();
        }
    }
}
