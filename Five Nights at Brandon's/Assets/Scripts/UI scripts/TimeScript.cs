using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    public float hour;
    void Start()
    {
        hour = 0;
    }

    // Update is called once per frame
    void Update()
    {
        hour = Time.timeSinceLevelLoad / 30;
        if (hour > 6 && Time.time > 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void FixedUpdate()
    {
        if (Mathf.Floor(hour) <= 0)
        {
            GetComponent<Text>().text = "Time: 12:00";
        }
        else
        {
            GetComponent<Text>().text = "Time: "+Mathf.Floor(hour)+":00";
        }
    }
}
