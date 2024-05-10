using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button[] buttons; // Assign buttons 0 and 1 for top, 2 for bottom in the inspector
    private int selectedIndex = 0;

    void Update()
    {
        HandleInput();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadScene();
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (selectedIndex == 2) // If on 'exit', move to 'level 1'
            {
                selectedIndex = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (selectedIndex < 2) // If on 'level 1' or 'level 2', move to 'exit'
            {
                selectedIndex = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (selectedIndex == 1) // If on 'level 2', move to 'level 1'
            {
                selectedIndex = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (selectedIndex == 0) // If on 'level 1', move to 'level 2'
            {
                selectedIndex = 1;
            }
        }

        UpdateButtonSelection();
    }

    void UpdateButtonSelection()
    {
        foreach (Button button in buttons)
        {
            bool isSelected = button == buttons[selectedIndex];
            // Assume each button has four children that are the corner images
            for (int i = 0; i < button.transform.childCount; i++)
            {
                Transform child = button.transform.GetChild(i);
                if (child.GetComponent<Image>() != null) // Check if the child is an Image
                {
                    child.gameObject.SetActive(isSelected);
                }
            }
        }
    }

    void LoadScene()
    {
       
        switch (selectedIndex)
        {
            case 0:
                SceneManager.LoadScene("Level-1");
                break;
            case 1:
                SceneManager.LoadScene("SampleA");
                break;
            case 2:
                SceneManager.LoadScene("Home");
                break;
        }
    }
}
