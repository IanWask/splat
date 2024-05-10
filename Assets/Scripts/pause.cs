// using UnityEngine;

// public class PauseScript : MonoBehaviour
// {
//     private bool isPaused = false;
//     private AudioSource[] allAudioSources;

//     void Start()
//     {
//         // Get all audio sources in the scene
//         allAudioSources = FindObjectsOfType<AudioSource>();
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Escape))
//         {
//             TogglePause();
//         }
//     }

//     void TogglePause()
//     {
//         isPaused = !isPaused;

//         if (isPaused)
//         {
//             Time.timeScale = 0f; // Pause the game

//             // Pause all audio sources
//             foreach (AudioSource audioSource in allAudioSources)
//             {
//                 audioSource.Pause();
//             }

//             // Additional pause logic like showing UI or locking cursor can be added here
//         }
//         else
//         {
//             Time.timeScale = 1f; // Resume the game

//             // Resume all audio sources
//             foreach (AudioSource audioSource in allAudioSources)
//             {
//                 audioSource.UnPause();
//             }

//             // Additional resume logic like hiding UI or unlocking cursor can be added here
//         }
//     }
// }


using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;
    private AudioSource[] allAudioSources;

    public RectTransform button1;
    public RectTransform button2;
    private Vector3 button1OriginalPosition;
    private Vector3 button2OriginalPosition;

    void Start()
    {
        // Get all audio sources in the scene
        allAudioSources = FindObjectsOfType<AudioSource>();

        // Store original positions of the buttons
        button1OriginalPosition = button1.localPosition;
        button2OriginalPosition = button2.localPosition;
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

            // Move buttons to desired coordinates when paused
            button1.localPosition = new Vector3(0f, -75f, 0f);
            button2.localPosition = new Vector3(0f, -150f, 0f);

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

            // Move buttons back to original positions when unpaused
            button1.localPosition = button1OriginalPosition;
            button2.localPosition = button2OriginalPosition;

            // Additional resume logic like hiding UI or unlocking cursor can be added here
        }
    }
}
