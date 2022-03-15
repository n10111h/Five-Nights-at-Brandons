using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text direction;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        text.fontSize = 12;
        text.text = "No escape, only way out is Brandon";
    }
    public void HowTo()
    {
        direction.fontSize = 12;
        direction.text = "A and D to move your view. Q and E to toggle doors.\nSpace to toggle Cams. Click on cam UI for respective cams.\n Other than that just survive idk.";
    }
}
