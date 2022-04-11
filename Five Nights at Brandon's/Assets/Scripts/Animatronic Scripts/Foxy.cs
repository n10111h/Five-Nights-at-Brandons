using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Foxy : MonoBehaviour
{
    public GameObject powerUI;
    private float power;
    private float time;
    private float jumpTime;
    private float whenTime;
    public short level;
    public int pos;
    public GameObject player;
    public GameObject curtains;
    public CameraUI cam;
    private float interpolateStart = -1f;
    void posUpdate()
    {
        switch (pos)
        {
            case 0:
                transform.position = new Vector3(3.3341f, 0.6277336f, -1.802125f);
                transform.rotation = Quaternion.Euler(90, 0, 90);
                curtains.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 1:
                transform.position = new Vector3(3.3341f, 0.6277336f, -1.802125f);
                transform.rotation = Quaternion.Euler(90, 0, 90);
                curtains.transform.rotation = Quaternion.Euler(0, 10, 0);
                break;
            case 2:
                transform.position = new Vector3(2.756f, 0.639f, -1.5981f);
                transform.rotation = Quaternion.Euler(90, 0, 90);
                curtains.transform.rotation = Quaternion.Euler(0, 20, 0);
                break;
            case 3:
                Vector3 startPos = new Vector3(1.303f, 0.26f, 1.874f);
                if (interpolateStart < 0.0f) interpolateStart = Time.time;
                transform.rotation = Quaternion.Euler(90, 0f, 50f);
                Vector3 endPos = new Vector3(1.303f, 0.26f, 5.071f);
                curtains.transform.rotation = Quaternion.Euler(0, 20, 0);
                if (Time.time - interpolateStart > 7)
                {
                    pos++;
                }
                else
                {
                    transform.position = Vector3.Lerp(startPos, endPos, (Time.time - interpolateStart)/5);
                }
                break;
            case 4:
                transform.rotation = Quaternion.Euler(90, 180, 115);
                transform.position = new Vector3(50f, 50f, 50f);
                if (time == 0.0f) time = Time.time;
                if (Time.time - time > 3)
                {
                    float rand = Random.Range(0.0f, 999.0f);
                    if (player.GetComponent<PlayerInput>().leftDoorClosed)
                    {
                        if (rand > (level * 40))
                        {
                            pos = 0;
                            time = 0;
                        }
                    }
                    else
                    {
                        pos = 5;
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
                if (Time.time - jumpTime > 10) {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
    Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
#endif
#if (UNITY_EDITOR)
    UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
    Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
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
    bool lookedAt()
    {
        if (!cam.IsOpen) return false;
        if (cam.camNum == 4)
            return true;
        else
            return false;
    }
    void FixedUpdate()
    {

        if (power <= 0)
        {

        }
        else
        {
            if (level != 0)
            {
                if (Time.time - whenTime == Time.time) whenTime = Time.time;
                if (Time.time - whenTime > (float) (35 / level))
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
                            if (pos < 3)
                            {
                                pos++;
                            }

                            whenTime = 0;
                        }
                    }
                }
                posUpdate();
            }
        }

    }
}
