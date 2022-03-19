using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonnie : MonoBehaviour
{
    public GameObject powerUI;
    private float power;
    private float time;
    public short level;
    private int pos;
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
                transform.position = new Vector3(1.265f, 0.535f, 4.554f);
                transform.rotation = Quaternion.Euler(75, -55, 0);
                break;
            case 5:
                transform.position = new Vector3(1.429f, 0.535f, 5.587f);
                transform.rotation = Quaternion.Euler(90, -55, 0);
                break;
            default:
                break;

        }
    }
    void Start()
    {
        time = Time.time;
        pos = 0;
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
        posUpdate();
    }
}
