using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplePauseMenu : MonoBehaviour
{
    public GameObject resumeButton;
    public GameObject mainMenuButton;
    public AudioSource gameMusic;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        resumeButton.SetActive(true);
        mainMenuButton.SetActive(true);
        if (gameMusic) gameMusic.Pause();

    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        resumeButton.SetActive(false);
        mainMenuButton.SetActive(false);
        if (gameMusic) gameMusic.Play();

    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
        if (gameMusic) gameMusic.Stop();

    }
}
