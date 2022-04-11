using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonnie : MonoBehaviour
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
                transform.position = new Vector3(0.623f, 1.087f, -5.518f);
                transform.rotation = Quaternion.Euler(90,130,90);
                break;
            case 1:
                transform.position = new Vector3(4.777f, 0.873f, -3.446f);
                transform.rotation = Quaternion.Euler(100, 130, -180);
                break;
            case 2:
                transform.position = new Vector3(-0.209f, 0.867f, -3.364f);
                transform.rotation = Quaternion.Euler(90, 180, -50);
                break;
            case 3:
                transform.position = new Vector3(2.289f, 0.535f, 2.558f);
                transform.rotation = Quaternion.Euler(90, 0, 90);
                break;
            case 4:
                transform.position = new Vector3(1.265f, 0.535f, 4f);
                transform.rotation = Quaternion.Euler(75, -55, 0);
                break;
            case 5:
                transform.rotation = Quaternion.Euler(90, -55, 0);
                if (player.GetComponent<PlayerInput>().leftLightEn)
                    transform.position = new Vector3(1.429f, 0.535f, 5.587f);
                else
                    transform.position = new Vector3(50f, 50f, 50f);
                if (time == 0.0f) time = Time.time;
                if (Time.time - time > 3) {
                    float rand = Random.Range(0.0f, 999.0f);
                    if (player.GetComponent<PlayerInput>().leftDoorClosed)
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
                            pos = 6;
                    }
                }
                break;
            case 6:
                if (Time.time - jumpTime == Time.time)
                {
                    jumpTime = Time.time;
                }
                transform.position = new Vector3(0.145f, 0.553f, 6.62f);
                transform.rotation = Quaternion.Euler(90, 90, 90);
                if (Time.time - jumpTime > 10)
                {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
    Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
#endif
#if (UNITY_EDITOR)
    UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
    Application.Quit();
#elif (UNITY_WEBGL)
    SceneManager.LoadScene(11);
#endif
                }
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
        if (power>0)
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
                        if (pos < 5) pos++;
                        whenTime = 0;
                    }
                }
            }
            posUpdate();
        }
    }
}
