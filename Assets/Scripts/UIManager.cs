using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI resetCounterText; 

    void Update()
    {
        if (GameManager.Instance != null && resetCounterText != null)
        {
            resetCounterText.text = "Resets: " + GameManager.Instance.ResetCount.ToString();
        }
    }
}
