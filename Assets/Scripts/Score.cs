using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int score = 0; // Player's score
    public Text scoreText; // Reference to the UI Text component to display score

    // Update the score text on UI
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Add points to the player's score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    //
    // OnCollisionEnter2D is called when the player collides with another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            // Access the script component attached to the collided object and retrieve its public value variable
            int coinValue = collision.gameObject.GetComponent<coins>().value;
            AddScore(coinValue);
        }
        else if (collision.gameObject.CompareTag("Lava"))
        {
            // Access the script component attached to the collided object and retrieve its public value variable
            int snakeValue = collision.gameObject.GetComponent<Snakes>().value;
             AddScore(snakeValue );
        }
    }

    // Example function to reset the score
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Call this to ensure the UI text is updated with the initial score value
        UpdateScoreUI();
    }
}
