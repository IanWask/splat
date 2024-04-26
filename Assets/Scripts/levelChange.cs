// using UnityEngine;
// using System.Collections;
// using UnityEngine.SceneManagement;

// public class save : MonoBehaviour
// {

//     public float pX;
//     public float pY;
//     public float pZ;

//     public int sceneBuildIndex;

//     // Level move zoned enter, if collider is a player
//     // Move game to another scene
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         print("Trigger Entered");

//         // Could use other.GetComponent<Player>() to see if the game object has a Player component
//         // Tags work too. Maybe some players have different script components?
//         if (other.tag == "Player")
//         {
//             // Player entered, so move level
//             print("Switching Scene to " + sceneBuildIndex);

//             SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
//         }
//     }

//     // Use this for initialization
//     void Start()
//     {
//         // Check if the values have been saved
//         if (PlayerPrefs.GetInt("Saved") == 1)
//         {
//             pX = PlayerPrefs.GetFloat("p_x");
//             pY = PlayerPrefs.GetFloat("p_y");
//             pZ = PlayerPrefs.GetFloat("p_z");

//             transform.position = new Vector3(pX, pY, pZ);

//             // Reset, so that the save will be used only once
//             PlayerPrefs.SetInt("Saved", 0);
//             PlayerPrefs.Save();
//         }
//     }
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.S))
//         {
//             position_save();
//             Debug.Log("Save");
//         }

//         if (Input.GetKeyDown(KeyCode.L))
//         {
//             position_load();
//             Debug.Log("Load");
//         }

//     }
//     void position_save()
//     {
//         PlayerPrefs.SetFloat("p_x", transform.position.x);
//         PlayerPrefs.SetFloat("p_y", transform.position.y);
//         PlayerPrefs.SetFloat("p_z", transform.position.z);

//         PlayerPrefs.SetInt("Saved", 1);
//         // You need to actually save the values!
//         PlayerPrefs.Save();
//     }
//     void position_load()
//     {
//         print("Switching Scene to " + sceneBuildIndex);
//         SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
//     }
// }

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int sceneBuildIndex; // The build index of the scene to load
    public Vector3 initialPosition = new Vector3(0f, 0f, 0f); // Initial position on the first level

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            // Save the player's x position and a flag indicating the position is saved
            PlayerPrefs.SetFloat("lastX", other.transform.position.x);
            PlayerPrefs.SetInt("positionSaved", 1);
            PlayerPrefs.Save();

            // Load the next level
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1) // Assuming level 0 is the first level
        {
            // If not on the first level and the position has been saved, set the new position
            if (PlayerPrefs.GetInt("positionSaved") == 1)
            {
                float lastX = PlayerPrefs.GetFloat("lastX");

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    // Set the player's position to the saved x and a high y value to start at the top of the level
                    player.transform.position = new Vector3(lastX, initialPosition.y, initialPosition.z);
                }

                // Reset the flag so it doesn't affect other scenes unintentionally
                PlayerPrefs.SetInt("positionSaved", 0);
                PlayerPrefs.Save();
            }
        }
        else
        {
            // On the first level, set the player to the initial start position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = initialPosition;
            }
        }
    }
}
