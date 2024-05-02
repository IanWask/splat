using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro text object
    public GameObject playerObject; // Reference to the player object with PlayerScore script

    private float timer = 0f;
    private bool scoreFrozen = false;

    void Update()
    {
        // Check if the score is not frozen
        if (!scoreFrozen)
        {
            // Check if the player GameObject reference is not set
            if (playerObject == null)
            {
                // Find the player GameObject by tag
                playerObject = GameObject.FindGameObjectWithTag("Player");
            }

            // Check if the player GameObject is found
            if (playerObject != null)
            {
                // Access the PlayerScore component attached to the player GameObject
                PlayerScore playerScore = playerObject.GetComponent<PlayerScore>();

                // Get the score value from the PlayerScore component
                int scoreValue = playerScore.score;

                // Display the score value on the TextMeshPro text object
                scoreText.text = "Score: " + scoreValue.ToString();
            }
            else
            {
                // Log a warning if the player GameObject is not found
                Debug.LogWarning("Player GameObject not found.");
            }

            // Update timer
            timer += Time.deltaTime;

            // Check if timer exceeds 150 seconds
            if (timer >= 142f)
            {
                // Freeze the score
                scoreFrozen = true;
            }
        }
    }
}

