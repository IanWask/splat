using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayTrial()
    {
        SceneManager.LoadScene("Level-1");
    }
    public void PlayEndless()
    {
        SceneManager.LoadScene("Endless");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}