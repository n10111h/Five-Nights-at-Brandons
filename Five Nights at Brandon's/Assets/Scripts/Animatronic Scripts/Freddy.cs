using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Freddy : MonoBehaviour
{
    public GameObject powerUI;
    private float power;
    private float time;
    private float jumpTime;
    private float whenTime;
    public short level;
    public int pos;
    public GameObject player;
    public CameraUI cam;
    void posUpdate()
    {
        switch (pos)
        {
            case 0:
                transform.position = new Vector3(-0.02829921f, 1.087964f, -5.518169f);
                transform.rotation = Quaternion.Euler(90, 130, 90);
                break;
            case 1:
                transform.position = new Vector3(-4.297f, 0.6f, -2.281f);
                transform.rotation = Quaternion.Euler(90, 130, 130);
                break;
            case 2:
                transform.position = new Vector3(4.351f, 0.617f, -4.164f);
                transform.rotation = Quaternion.Euler(90, 180, -160);
                break;
            case 3:
                transform.position = new Vector3(-0.46f, 1.13f, -3.73f);
                transform.rotation = Quaternion.Euler(19.299f, 20.642f, -3.076f);
                break;
            case 4:
                transform.rotation = Quaternion.Euler(90, 180, 115);
                transform.position = new Vector3(-1.092f, 0.715f, 3.505f);
                if (time == 0.0f) time = Time.time;
                if (Time.time - time > 3)
                {
                    float rand = Random.Range(0.0f, 999.0f);
                    if (player.GetComponent<PlayerInput>().rightDoorClosed)
                    {
                        if (rand > (level * 40))
                        {
                            pos = 4;
                            time = 0;
                        }
                    }
                    else
                    {
                        if (rand < (level))
                        {
                            if (player.transform.eulerAngles.y > 200)
                                time = 0;
                            else
                                pos = 5;
                        }

                    }
                }
                break;
            case 5:
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
    bool lookedAt() {
        switch (pos)
        {
            case 0:
                if (cam.camNum == 6)
                    return true;
                else
                    return false;
            case 1:
                if (cam.camNum == 7)
                    return true;
                else
                    return false;
            case 2:
                if (cam.camNum == 8)
                    return true;
                else
                    return false;
            default:
                return false;
        }
    }
    void FixedUpdate()
    {
        if (level != 0)
        {
            if (power <= 0)
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
                if (Time.time - whenTime == Time.time) whenTime = Time.time;
                if (Time.time - whenTime > (float)(40 / level))
                {
                    if (lookedAt())
                    {
                        whenTime = 0;
                    }
                    else
                    {
                        float rand = Random.Range(0.0f, 99.0f);
                        if (rand < level)
                        {
                            if (pos < 4)
                            {
                                if (pos == 0)
                                    pos++;
                            }

                            whenTime = 0;
                        }
                    }
                }
            }
            posUpdate();
        }
    }
}
