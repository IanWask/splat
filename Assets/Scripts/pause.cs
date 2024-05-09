using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;
    private AudioSource[] allAudioSources;

    void Start()
    {
        // Get all audio sources in the scene
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game

            // Pause all audio sources
            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.Pause();
            }

            // Additional pause logic like showing UI or locking cursor can be added here
        }
        else
        {
            Time.timeScale = 1f; // Resume the game

            // Resume all audio sources
            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.UnPause();
            }

            // Additional resume logic like hiding UI or unlocking cursor can be added here
        }
    }
}
